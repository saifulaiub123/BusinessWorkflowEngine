import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS = [
  {
    title: 'Dashboard',
    icon: 'grid-outline',
    link: '/feature/dashboard',
    role: ['Admin','User','Partner'],
    home: true,
  },
  {
    title: 'Hangfire Dashboard',
    icon: 'activity-outline',
    link: '/feature/hangfire',
    role: ['Admin'],
  },
  {
    title: 'Script',
    icon: 'book-open-outline',
    link: '/feature/script',
    role: ['Admin','User'],
    children: [
      {
        title: 'List',
        icon: 'list-outline',
        link: '/feature/script/list',
        hidden: false,
      },{
        title: 'Add',
        icon: 'file-add-outline',
        link: '/feature/script/add-edit',
        hidden: false,
      }
    ]
  },
  {
    title: 'Script History',
    icon: 'file-text-outline',
    link: '/feature/script/history',
    role: ['Admin','User']
  },
  {
    title: 'User',
    icon: 'people-outline',
    link: '/feature/user',
    role: ['Admin']
  },
];
