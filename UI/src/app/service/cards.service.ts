import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Card } from '../Model/card.model';
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CardsService {

  baseurl = 'https://localhost:7047/api/Card';
  constructor(private http: HttpClient) {

   }

  //getAllCards
  getAllCards(): Observable<Card[]>{
    return this.http.get<Card[]>(this.baseurl);

  }

  //addCard
  addCard(card : Card) : Observable<Card>{
    card.id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<Card>(this.baseurl , card);
  }

  //deleteCard
  deleteCard(id:string) :Observable<Card>{
    return this.http.delete<Card>(this.baseurl+'/'+id);
  }
}
