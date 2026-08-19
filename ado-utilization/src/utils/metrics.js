import { eachDayOfInterval, isWeekend, parseISO } from 'date-fns'

// Count working days in a range, excluding weekends and given days-off
export function countWorkingDays(startStr, endStr, daysOff = []) {
  if (!startStr || !endStr) return 0
  try {
    const start = parseISO(startStr)
    const end = parseISO(endStr)
    const offDates = new Set()

    daysOff.forEach(d => {
      try {
        const ds = parseISO(d.start || d)
        const de = parseISO(d.end || d.start || d)
        eachDayOfInterval({ start: ds, end: de }).forEach(day =>
          offDates.add(day.toISOString().slice(0, 10))
        )
      } catch {}
    })

    return eachDayOfInterval({ start, end }).filter(day => {
      if (isWeekend(day)) return false
      if (offDates.has(day.toISOString().slice(0, 10))) return false
      return true
    }).length
  } catch {
    return 0
  }
}

// Plan Time = capacityPerDay × working days in iteration
export function calcPlanTime(capacityPerDay, iterStart, iterEnd, memberDaysOff = []) {
  const workDays = countWorkingDays(iterStart, iterEnd, memberDaysOff)
  return Math.round(capacityPerDay * workDays * 100) / 100
}

// Actual Capacity = capacityPerDay × (working days - member days off)
// (Same as plan time — member days off already excluded from countWorkingDays)
export function calcActualCapacity(capacityPerDay, iterStart, iterEnd, memberDaysOff = []) {
  return calcPlanTime(capacityPerDay, iterStart, iterEnd, memberDaysOff)
}

// Utilization % = actualHours / actualCapacity × 100
export function calcUtilizationPct(actualHours, actualCapacity) {
  if (!actualCapacity) return actualHours > 0 ? 100 : 0
  return Math.round((actualHours / actualCapacity) * 1000) / 10
}

// Compute full metrics for one member row
export function computeMemberMetrics(member) {
  const { capacityPerDay, memberDaysOff, actualHours, ...rest } = member
  const iterStart = rest.iterationStart
  const iterEnd = rest.iterationEnd

  const planTime = calcPlanTime(capacityPerDay, iterStart, iterEnd, memberDaysOff)
  const actualCapacity = calcActualCapacity(capacityPerDay, iterStart, iterEnd, memberDaysOff)
  const utilPct = calcUtilizationPct(actualHours, actualCapacity)

  return {
    ...rest,
    capacityPerDay,
    memberDaysOff,
    actualHours,
    planTime,
    actualCapacity,
    utilPct,
    daysOff: memberDaysOff.length
  }
}

// Aggregate rows for summary
export function aggregateRows(rows) {
  return rows.reduce((acc, r) => ({
    planTime: acc.planTime + (r.planTime || 0),
    actualCapacity: acc.actualCapacity + (r.actualCapacity || 0),
    actualHours: acc.actualHours + (r.actualHours || 0)
  }), { planTime: 0, actualCapacity: 0, actualHours: 0 })
}

export function utilColor(pct) {
  if (pct >= 100) return '#c0392b'
  if (pct >= 80) return '#1a7340'
  if (pct >= 50) return '#b45309'
  return '#6b7280'
}

export function utilBg(pct) {
  if (pct >= 100) return '#fce8e6'
  if (pct >= 80) return '#e6f4ea'
  if (pct >= 50) return '#fff3e0'
  return '#f3f4f6'
}
