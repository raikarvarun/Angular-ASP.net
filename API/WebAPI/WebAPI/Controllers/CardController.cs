using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : Controller
    {
        private CardsDbContext cardsDbContext;

        public CardController(CardsDbContext cardsDbContext )
        {
            this.cardsDbContext = cardsDbContext;
        }

        private readonly CardsDbContext CardsDbContext;
        

        //GetAll Cards
        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = await cardsDbContext.Cards.ToListAsync();
            return Ok(cards);
        }

        //get single card
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCard")]
        public async Task<IActionResult> GetCard([FromRoute] Guid id)
        {
            var card = await cardsDbContext.Cards.FirstOrDefaultAsync( x=> x.Id == id);
            if (card != null)
            {
                return Ok(card);
            }
            return NotFound("NOT found");
        }

        //post single card
        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody] Card card)
        {
            card.Id = Guid.NewGuid();
            await cardsDbContext.Cards.AddAsync(card);
            await cardsDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCard) , new { id = card.Id } , card);
        }


        //Update a card
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCard([FromRoute] Guid id, [FromBody] Card card)
        {
            var existingcard = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if (existingcard != null)
            {
                
                existingcard.CardHolderName = card.CardHolderName;
                existingcard.CardHolderNumber = card.CardHolderNumber;
                existingcard.ExpiryMonth = card.ExpiryMonth;
                existingcard.ExpiryYear = card.ExpiryYear;
                existingcard.CVV = card.CVV;

                await cardsDbContext.SaveChangesAsync();
                return Ok(existingcard);

            }
            return NotFound("NOt FOund");
        }

        //Delete a card
        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteCard([FromRoute] Guid id)
        {
            var existingcard = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if (existingcard != null)
            {

                cardsDbContext.Remove(existingcard);
                await cardsDbContext.SaveChangesAsync();
                return Ok(existingcard);

            }
            return NotFound("NOt FOund");
        }
    }
}
