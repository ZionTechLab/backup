# Menu Arrangement

Controls what appears in the left drawer for every screen in the app — the order, the grouping, and which roles can see each item.

*Mock illustrations below — not real screenshots of your instance.*

## The Tree

Every menu item is either a **group** (a folder, like "Petty Cash" or "Transactions") or a **leaf** (an actual screen, like "IOU Settlement"). Groups can contain other groups, so the drawer can nest a few levels deep.

![Menu tree with drag-and-drop reordering](/help/images/menu-tree.svg)

## Reordering — Two Ways

**Drag and drop** — grab a row by the grip handle on the left and drop it onto another row. Dropping onto a group moves the item inside that group; dropping onto a leaf item places it as that item's next sibling. Dropping in the empty area below the tree moves an item back to the top level.

**Arrows** — click the ↑ / ↓ buttons on a row to swap it with its neighbor. Slower, but exact — useful on a touchpad or when drag-and-drop feels imprecise.

Reordering only takes effect once you click **Save Arrangement** at the top — nothing is saved as you drag, so you can experiment freely and back out with a page refresh if you're not happy with it.

## Editing an Item

Click the pencil icon on any row to open its editor:

![Menu item editor](/help/images/menu-editor.svg)

| Field | Meaning |
|---|---|
| Name | What shows in the drawer |
| Route | The URL path the item links to (leaves only — groups use `#`) |
| Parent | Which group this item lives under, or *(Top level)* |
| Icon | Pick from the icon grid |
| Is Group | Turns this item into a folder instead of a clickable screen |
| Active | Unchecking hides the item everywhere, for everyone, without deleting it |

## Adding a New Item

- **New Item** (top right) adds a top-level item.
- The **+** button on any group row adds a new item directly inside that group.

A new item is saved immediately once you click Save in its editor — unlike reordering, creating an item doesn't wait for Save Arrangement.

## Role Visibility

The small badges on the right of each row (e.g. **ADM**, **USR**) are per-role toggles — click one to show or hide that specific menu item for that role. This only controls whether the item *appears in the drawer*; it does not grant or remove the underlying screen permission. A role can see a menu item and still hit "Access denied" if it doesn't hold the permission the screen itself checks — see [Permissions & Roles](permissions.md).

## Who Can Use This

Gated by the `menu-manage` permission. If you don't see Menu Arrangement in your own drawer, you don't have it.
