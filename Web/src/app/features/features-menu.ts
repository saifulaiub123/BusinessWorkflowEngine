import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS = [
  {
    title: 'Dashboard',
    icon: 'keypad-outline',
    link: '/feature/dashboard',
    role: ['Admin','User','Partner'],
    home: true,
  },
  {
    title: 'User',
    icon: 'keypad-outline',
    link: '/feature/user',
    role: ['Admin']
  },
  {
    title: 'Script',
    icon: 'keypad-outline',
    link: '/feature/script',
    role: ['Admin','User']
  },
  // {
  //   title: 'Reward Points',
  //   icon: 'keypad-outline',
  //   link: '/feature/reward-points',
  //   role: ['User']
  // },
  // {
  //   title: 'Reports',
  //   icon: 'keypad-outline',
  //   link: '/feature/reports',
  //   role: ['Partner']
  // },
];
