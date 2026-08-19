# ADO Utilization Dashboard

## Setup (one time)
```
npm install
```

## Run
```
npm run dev
```
Then open http://localhost:5173

## First launch
1. Enter your org name: `HAYADVANTIS`
2. Paste your PAT (needs Read access on Work Items + Project & Team)
3. Click Connect

## Usage
- Set date range in the top bar
- Click **Fetch Data**
- Switch between **Consolidated** and **By Project** views
- Use filters (Project, Team, Member, Iteration, Utilization %)
- Drill down: Project → Team → Iteration → Member → Work Items
- Click **Export Excel** for multi-sheet export

## Excel export sheets
| Sheet | Contents |
|---|---|
| Consolidated Summary | One row per project with totals |
| Member Detail | All members across all projects |
| [Per project] | One sheet per project |
| Work Items | All tasks/bugs/stories |
