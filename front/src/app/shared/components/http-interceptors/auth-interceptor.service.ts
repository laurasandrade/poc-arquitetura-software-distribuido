import { Injectable } from '@angular/core';
import {
  HttpEvent, HttpInterceptor, HttpHandler, HttpRequest
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor {

  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let token = localStorage.getItem('accessToken');
    if (token) {
      token = 'Bearer ' + token;
      const authReq = req.clone({ setHeaders: { Authorization: token } });
      return next.handle(authReq);
    } else {
      return next.handle(req);
    }
  }
}
