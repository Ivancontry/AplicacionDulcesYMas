import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseHttp } from '../models/response.model';
import { environment } from 'src/environments/environment.prod';

@Injectable({
	providedIn: 'root'
})
export class CategoriaService {

	constructor(private httpClient: HttpClient) { }
	getSubCategorias(): Observable<ResponseHttp> {
		return this.httpClient.get<ResponseHttp>(`${environment.baseUrl}Categoria/subCategoria`);
	}
}
