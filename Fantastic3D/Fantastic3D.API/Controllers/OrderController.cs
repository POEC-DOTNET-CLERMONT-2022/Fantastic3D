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
        [HttpGet("{id}/Purchases/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetPurchases(int orderId)
        {
            var data = _purchasesData.GetAllAsync().Result;
            return (data.Any()) ? Ok(data) : NoContent();
        }

        // GET api/<GenericController>/5
        /// <summary>
        /// Retrieves the informations of a database content
        /// </summary>
        /// <param name="id" example="5">The element ID.</param>
        [HttpGet("{id}/Purchases/{purchaseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPurchase(int id, int purchaseId)
        {
            try
            {
                var retrievedData = _purchasesData.GetAsync(purchaseId).Result;
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
        [HttpPost("{id}/Purchases/")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostPurchase(int id, [FromBody] PurchaseDto newValue)
        {
            try
            {
                newValue.OrderId = id;
                _purchasesData.AddAsync(newValue);
                return Created(Request.Query.ToString(), newValue);
            }
            catch (Exception e)
            {
                return BadRequest(newValue);
            }
        }

        // PUT api/<OrderController>/101/Purchases/3
        /// <summary>
        /// Changes the informations of an user.
        /// </summary>
        /// <param name="id" example="5">The user's ID.</param>
        /// <param name="value">Full description of an user</param>
        [HttpPut("{id}/Purchases/{purchaseId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PutPurchase(int id, int purchaseId, [FromBody] PurchaseDto updatedValue)
        {
            try
            {
                _purchasesData.UpdateAsync(purchaseId, updatedValue);
                return base.Created(Request.Query.ToString(), updatedValue);
            }
            catch (Exception e)
            {
                return BadRequest(updatedValue);
            }
        }

        // DELETE api/<OrderController>/101/Purchases/3
        /// <summary>
        /// Deletes a value by its id.
        /// </summary>
        /// <param name="id" example="5">The user's ID.</param>
        [HttpDelete("{id}/Purchases/{purchaseId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletePurchase(int id, int purchaseId)
        {
            try
            {
                _purchasesData.DeleteAsync(purchaseId);
                return NoContent();
            }
            catch
            {
                return NotFound(purchaseId);
            }
        }
    }
}
