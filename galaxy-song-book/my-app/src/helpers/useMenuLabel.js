import { useSelector } from 'react-redux';
import { selectInitData } from '../features/auth';

// Ties a screen's title to its Menu Arrangement label instead of a hardcoded
// string, so renaming a menu item there updates the form/list header too.
export default function useMenuLabel(route, fallback) {
  const initData = useSelector(selectInitData);
  const found = initData?.menuItems_Flat?.find((item) => item.route === route);
  return found?.displayName || fallback;
}
