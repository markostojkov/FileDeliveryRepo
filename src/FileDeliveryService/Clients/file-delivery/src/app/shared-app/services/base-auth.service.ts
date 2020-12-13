import { HttpClient, HttpHeaders, HttpParams, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export abstract class BaseApiService {
  private baseApiUrl = 'http://localhost:57700/api/';

  public httpHeaders: HttpHeaders = new HttpHeaders({
    'Content-Type': 'application/json',
    Accept: 'application/json'
  });

  constructor(protected http: HttpClient) {}

  public get<T>(url: string, params: HttpParams = new HttpParams()): Observable<T> {
    return this.http.get<T>(`${this.baseApiUrl}${url}`, { headers: this.httpHeaders, params });
  }

  public getWithHeaderAppend<T>(url: string, name: string, value: string, params: HttpParams = new HttpParams()): Observable<T> {
    return this.http.get<T>(`${this.baseApiUrl}${url}`, { headers: this.httpHeaders.append(name, value), params });
  }

  // tslint:disable-next-line: ban-types
  public post<T>(url: string, data: Object = {}): Observable<T> {
    return this.http.post<T>(`${this.baseApiUrl}${url}`, JSON.stringify(data), { headers: this.httpHeaders });
  }

  // tslint:disable-next-line: ban-types
  public put<T>(url: string, data: Object = {}): Observable<T> {
    return this.http.put<T>(`${this.baseApiUrl}${url}`, JSON.stringify(data), { headers: this.httpHeaders });
  }

  public delete<T>(url: string): Observable<T> {
    return this.http.delete<T>(`${this.baseApiUrl}${url}`, { headers: this.httpHeaders });
  }

  // tslint:disable-next-line: ban-types
  public deleteWithBody<R>(url: string, data: Object = {}): Observable<R> {
    return this.http.request<R>('delete', `${this.baseApiUrl}${url}`, { body: JSON.stringify(data), headers: this.httpHeaders });
  }

  // tslint:disable-next-line: ban-types
  public patch<T>(url: string, data: Object = {}): Observable<T> {
    return this.http.patch<T>(`${this.baseApiUrl}${url}`, JSON.stringify(data), { headers: this.httpHeaders });
  }

  public request(request: HttpRequest<any>): Observable<any> {
    return this.http.request(request);
  }
}
