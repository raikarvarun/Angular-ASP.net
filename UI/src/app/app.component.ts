import { Component , OnInit} from '@angular/core';
import { Card } from './Model/card.model';
import { CardsService } from './service/cards.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'cards';
  cards : Card[] = []  ;  
  card : Card= {
    id : '',
    cardHolderName : '',
    cardHolderNumber : '',
    expiryMonth: '',
    expiryYear: '',
    cvv : ''
  }
  constructor(private cardService  : CardsService){ 

  }

  ngOnInit(): void{
     this.getAllCards();
  }

  clearForm(){
	this.card ={
		id : '',
		cardHolderName : '',
		cardHolderNumber : '',
		expiryMonth: '',
		expiryYear: '',
		cvv : ''
	  }
  }

  getAllCards(){
    this.cardService.getAllCards().subscribe(
      response => {
        this.cards = response;
       console.log(response);
    });

  }

  
  onSubmit(){
	
	console.log(this.card);
	this.cardService.addCard(this.card).subscribe(
		response =>{
			console.log(response); 
			this.getAllCards();
			this.clearForm();
	});
	
  }

  cardRowClicked(takencard:Card){
	console.log("cardRowClicked()");
	this.card = takencard;
  }

  //delete card
  deleteCard(id:string){
	this.cardService.deleteCard(id).subscribe(
		response => {
			this.getAllCards();
		}
	)
	;
  }
}
