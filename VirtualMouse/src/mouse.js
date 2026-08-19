// Mouse control core. Wraps nut.js.
// This module is the shared surface the voice layer will call later.
import { mouse, Point, Button } from "@nut-tree-fork/nut-js";

// Instant moves. No tweening, snappy for a CLI.
mouse.config.mouseSpeed = 5000;

export async function getPosition() {
  const p = await mouse.getPosition();
  return { x: p.x, y: p.y };
}

export async function moveTo(x, y) {
  await mouse.setPosition(new Point(Math.round(x), Math.round(y)));
}

export async function moveBy(dx, dy) {
  const p = await mouse.getPosition();
  await mouse.setPosition(new Point(Math.round(p.x + dx), Math.round(p.y + dy)));
}

export async function leftClick() {
  await mouse.leftClick();
}

export async function rightClick() {
  await mouse.rightClick();
}

export async function doubleClick() {
  await mouse.doubleClick(Button.LEFT);
}

export async function scroll(direction, amount = 3) {
  switch (direction) {
    case "up":
      await mouse.scrollUp(amount);
      break;
    case "down":
      await mouse.scrollDown(amount);
      break;
    case "left":
      await mouse.scrollLeft(amount);
      break;
    case "right":
      await mouse.scrollRight(amount);
      break;
    default:
      throw new Error(`bad scroll direction: ${direction}`);
  }
}
