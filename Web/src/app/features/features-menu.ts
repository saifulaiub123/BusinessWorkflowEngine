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
    title: 'Hangfire Dashboard',
    icon: 'keypad-outline',
    link: '/feature/hangfire',
    role: ['Admin'],
  },
  {
    title: 'Script',
    icon: 'keypad-outline',
    link: '/feature/script',
    role: ['Admin','User']
  },
  {
    title: 'Script History',
    icon: 'keypad-outline',
    link: '/feature/script/history',
    role: ['Admin','User']
  },
  {
    title: 'User',
    icon: 'keypad-outline',
    link: '/feature/user',
    role: ['Admin']
  },
];
