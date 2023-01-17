
import { NbAuthJWTToken, NbAuthOAuth2JWTToken, NbPasswordAuthStrategy } from '@nebular/auth';
import { environment } from '../../environments/environment';

export const socialLinks = [
  {
    url: 'https://github.com/akveo/nebular',
    target: '_blank',
    icon: 'github',
  },
  {
    url: 'https://www.facebook.com/akveo/',
    target: '_blank',
    icon: 'facebook',
  },
  {
    url: 'https://twitter.com/akveo_inc',
    target: '_blank',
    icon: 'twitter',
  },
];

export const authOptions = {
  strategies: [
    NbPasswordAuthStrategy.setup({
      name: 'email',
      baseEndpoint: environment.apiUrl,
      token: {
        class: NbAuthJWTToken,
        key: 'token'
      },
      errors:{
        key: 'Errors'
      },
      login: {
        endpoint: '/auth/login',
        method: 'post',
        redirect: {
          success: '/feature',
          failure: '/'
        }
      },
      register: {
        endpoint: '/auth/register',
        method: 'post',
        requireValidToken: false,
        redirect: {
          success: '/auth/login',
          failure: '/'
        }
      },
      logout: {
        method: null,
        redirect: {
          success: '/auth/login',
          failure: '/' }
      },
    }),
  ],
  forms: {
    login: {

    },
    register: {

    },
    validation: {
      name: {
        required: true,
        minLength: 2,
        maxLength: 20,
      },
      surname: {
        required: true,
        minLength: 2,
        maxLength: 20,
      },
    },
    logout: {
      redirectDelay: 1000
    }
  },
};
