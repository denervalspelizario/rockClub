import { ApplicationConfig } from '@angular/core'; // ficar esperto com esses imports
import { provideRouter } from '@angular/router';
import { provideHttpClient, withFetch } from '@angular/common/http';




import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), provideHttpClient(withFetch()),]
};
