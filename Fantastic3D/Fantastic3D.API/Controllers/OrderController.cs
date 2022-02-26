using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using Fantastic3D.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Fantastic3D.API.Controllers
{
    public class OrderController : GenericController<OrderDto, OrderEntity>
    {
        internal IDataManager<PurchaseDto, PurchaseEntity> _purchasesData;
        public OrderController(IDataManager<OrderDto, OrderEntity> dataManager, IDataManager<PurchaseDto, PurchaseEntity> purchaseDataManager) : base(dataManager)
        {
            _purchasesData = purchaseDataManager;
        }

        // GET: api/<OrderController>/101/Purchases
        /// <summary>
        /// Retrieves all the users.
        /// </summary>
        [HttpGet("{id}/Purchase/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetPurchases(int orderId)
        {
            var data = await _purchasesData.GetAllAsync();
            return (data.Any()) ? Ok(data) : NoContent();
        }

        // GET api/<GenericController>/5
        /// <summary>
        /// Retrieves the informations of a database content
        /// </summary>
        /// <param name="id" example="5">The element ID.</param>
        [HttpGet("{id}/Purchase/{purchaseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPurchase(int id, int purchaseId)
        {
            try
            {
                var retrievedData = await _purchasesData.GetAsync(purchaseId);
                if (retrievedData == null)
                    return NotFound(purchaseId);
                return Ok(retrievedData);
            }
            catch (InvalidOperationException ioe)
            {
                return BadRequest(ioe.Message);
            }
        }

        // POST api/<OrderController>/101/Purchases
        [HttpPost("{id}/Purchase/")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostPurchase(int id, [FromBody] PurchaseDto newValue)
        {
            try
            {
                newValue.OrderId = id;
                await _purchasesData.AddAsync(newValue);
                return Created(Request.Query.ToString(), newValue);
            }
            catch (DataRecordException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<OrderController>/101/Purchases/3
        /// <summary>
        /// Changes the informations of an user.
        /// </summary>
        /// <param name="id" example="5">The user's ID.</param>
        /// <param name="value">Full description of an user</param>
        [HttpPut("{id}/Purchase/{purchaseId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutPurchase(int id, int purchaseId, [FromBody] PurchaseDto updatedValue)
        {
            try
            {
                await _purchasesData.UpdateAsync(purchaseId, updatedValue);
                return base.Created(Request.Query.ToString(), updatedValue);
            }
            catch (DataRecordException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<OrderController>/101/Purchases/3
        /// <summary>
        /// Deletes a value by its id.
        /// </summary>
        /// <param name="id" example="5">The user's ID.</param>
        [HttpDelete("{id}/Purchase/{purchaseId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePurchase(int id, int purchaseId)
        {
            try
            {
                await _purchasesData.DeleteAsync(purchaseId);
                return NoContent();
            }
            catch (DataRecordException dre)
            {
                return NotFound(dre.Message);
            }
        }
    }
}
