using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PackgingAPI.Helpers;
using PackgingAPI.Models;
using PackgingAPI.Models.ViewModels;

namespace PackgingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly PackgingDB _context;
        private readonly IMapper _mapper;
        private static ProductViewModel item = null;
        private readonly IUrlHelper _urlHelper;

        public ProductsController(PackgingDB context, IMapper mapper, IUrlHelper urlHelper)
        {
            _context = context;
            _mapper = mapper;
            _urlHelper = urlHelper;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                // Retrive products list
                var products = _mapper.Map<List<ProductViewModel>>(await _context.Products.ToListAsync());

                if (products == null)
                {
                    return NotFound();
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> GetSingle(int? productId)
        {
            if (productId == null)
            {
                return BadRequest();
            }

            try
            {
                //Retrive product by id
                var product = _mapper.Map<ProductViewModel>(await _context.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync());

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetPlacesListItem")]
        public async Task<IActionResult> GetPlacesListItem()
        {
            try
            {
                // Retrive places list
                var places = _mapper.Map<List<ListItemViewModel>>(await _context.Places.ToListAsync());

                if (places == null)
                {
                    return NotFound();
                }

                return Ok(places);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("SearchPlaces")]
        public async Task<IActionResult> SearchPlaces(string place)
        {
            try
            {
                var places = _mapper.Map<List<PlaceViewModel>>(await _context.Places.Where(pp => pp.Name.Contains(place)).ToListAsync());

                if (places == null)
                {
                    return NotFound();
                }

                return Ok(places);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetProductsListItem")]
        public async Task<IActionResult> GetProductsListItem()
        {
            try
            {
                var products = _mapper.Map<List<ListItemViewModel>>(await _context.Products.ToListAsync());

                if (products == null)
                {
                    return NotFound();
                }

                return Ok(products);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetProductsPlaces")]
        public async Task<IActionResult> GetProductsPlaces()
        {
            try
            {
                // Retrive products places list
                var productsPlaces = _mapper.Map<List<ProductPlaceGridViewModel>>(await _context.ProductPlaces.ToListAsync());

                if (productsPlaces == null)
                {
                    return NotFound();
                }

                return Ok(productsPlaces);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("SearchProductsPlaces")]
        public async Task<IActionResult> SearchProductsPlaces(string sku, int warehousesTypeId)
        {
            try
            {
                // Retrive products places list
                var productsPlaces = _mapper.Map<List<SearchProductViewModel>>(await _context.ProductPlaces.Include(pp => pp.Product).Include(ppp => ppp.WarehousesType)
                    .Where(p => p.Product.Sku
                    .Contains(sku ?? string.Empty) && p.WarehousesTypeId == warehousesTypeId).ToListAsync());

                if (productsPlaces == null)
                {
                    return NotFound();
                }

                return Ok(productsPlaces);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetInventoryBalance")]
        public async Task<IActionResult> GetInventoryBalance(int? productPlaceId)
        {
            if (productPlaceId == null)
            {
                return BadRequest();
            }

            try
            {
                //Retrive record by id
                var entity = _mapper.Map<EditInventoryBalance>(await _context.ProductPlaces.Include(pp => pp.Place).Include(ppp => ppp.Product).Include(pppp => pppp.WarehousesType).Where(p => p.ProductPlaceId == productPlaceId).FirstOrDefaultAsync());

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateInventoryBalance")]
        public async Task<IActionResult> UpdateInventoryBalance([FromBody]EditInventoryBalance model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Retrive the object from database
                    var entity = _context.ProductPlaces.FirstOrDefault(item => item.ProductPlaceId == Convert.ToInt32(model.InventoryBalanceID));

                    // Validate entity is not null
                    if (entity != null)
                    {
                        // Make changes on entity
                        entity.Count = model.Count;
                        entity.Instruction = model.Instruction;

                        // Update entity in DbSet
                        _context.ProductPlaces.Update(entity);

                        // Save changes in database
                        await _context.SaveChangesAsync();
                        return Ok(model);
                    }
                    else
                        return NotFound();

                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("GetHistories")]
        public async Task<IActionResult> GetHistories()
        {
            try
            {
                //Retrive record by id               
                var histories = _mapper.Map<List<HistoryViewModel>>(await _context.Histories.ToListAsync());

                if (histories == null)
                {
                    return NotFound();
                }

                return Ok(histories);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> Add([FromBody]ProductToCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Init product object
                    var newProduct = _mapper.Map<Product>(model);
                    newProduct.CreatedDate = DateTime.Now;

                    //Adding new object to database
                    await _context.Products.AddAsync(newProduct);
                    await _context.SaveChangesAsync();

                    if (newProduct.ProductId > 0)
                    {
                        return Ok(newProduct.ProductId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("ReportProduct")]
        public async Task<IActionResult> ReportProduct([FromBody]ProductPlaceViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Init product object
                    var newProductPlace = new ProductPlace();
                    newProductPlace.CreatedDate = DateTime.Now;

                    //Adding new object to database
                    await _context.ProductPlaces.AddAsync(newProductPlace);
                    await _context.SaveChangesAsync();

                    if (newProductPlace.PlaceId > 0)
                    {
                        return Ok("הרשומה נקלטה בהצלחה");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("AddProductPlace")]
        public async Task<IActionResult> AddProductPlace([FromBody]AddProductPlaceViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Init product place entity
                    var newProductPlace = new ProductPlace();
                    newProductPlace.ProductId = model.ProductId;
                    newProductPlace.Instruction = model.Instruction;
                    newProductPlace.Count = model.Count;
                    newProductPlace.PlaceId = model.PlaceId;
                    newProductPlace.WarehousesTypeId = 1;
                    newProductPlace.CreatedDate = DateTime.Now;

                    //Adding new entity to database
                    await _context.ProductPlaces.AddAsync(newProductPlace);
                    await _context.SaveChangesAsync();

                    if (newProductPlace.ProductId > 0)
                    {
                        return Ok(newProductPlace);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int? productId)
        {
            int result = 0;

            if (productId == null)
            {
                return BadRequest();
            }

            try
            {
                //Retrive the object from database
                var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == Convert.ToInt32(productId));

                if (product != null)
                {
                    //Delete that object
                    _context.Products.Remove(product);
                    //Save the changes
                    result = await _context.SaveChangesAsync();
                }

                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> Update([FromBody]ProductToEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Retrive the object from database
                    var entity = _context.Products.FirstOrDefault(item => item.ProductId == Convert.ToInt32(model.ProductId));

                    // Validate entity is not null
                    if (entity != null)
                    {
                        // Make changes on entity
                        entity.EditDate = DateTime.Now;
                        entity.Image = model.Image;
                        entity.Name = model.Name;
                        entity.ProductId = model.ProductId;
                        entity.Sku = model.Sku;
                        entity.Sorting = model.Sorting;

                        // Update entity in DbSet
                        _context.Products.Update(entity);

                        // Save changes in database
                        await _context.SaveChangesAsync();
                        return Ok(model);
                    }
                    else
                        return NotFound();

                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpGet(Name = nameof(GetAll))]
        public IActionResult GetAll([FromQuery] QueryParameters queryParameters)
        {
            var allProducts = GetAllTwo(queryParameters).ToList();

            var allItemCount = _context.Products.Count();

            var paginationMetadata = new
            {
                totalCount = allItemCount,
                pageSize = queryParameters.PageCount,
                currentPage = queryParameters.Page,
                totalPages = queryParameters.GetTotalPages(allItemCount)
            };

            Response.Headers.Add("X-Pagination",JsonConvert.SerializeObject(paginationMetadata));

            var links = CreateLinksForCollection(queryParameters, allItemCount);

            var toReturn = allProducts.Select(x => ExpandSingleItem(x));
            return Ok(new
            {
                value = toReturn,
                links = links
            }); 
        }

        private List<LinkDto> CreateLinksForCollection(QueryParameters queryParameters, int totalCount)
        {
            var links = new List<LinkDto>();

            links.Add(
             new LinkDto(_urlHelper.Link(nameof(Add), null), "create", "POST"));

            // self 
            links.Add(
             new LinkDto(_urlHelper.Link(nameof(GetAll), new
             {
                 pagecount = queryParameters.PageCount,
                 page = queryParameters.Page,
                 orderby = queryParameters.OrderBy
             }), "self", "GET"));

            links.Add(new LinkDto(_urlHelper.Link(nameof(GetAll), new
            {
                pagecount = queryParameters.PageCount,
                page = 1,
                orderby = queryParameters.OrderBy
            }), "first", "GET"));

            links.Add(new LinkDto(_urlHelper.Link(nameof(GetAll), new
            {
                pagecount = queryParameters.PageCount,
                page = queryParameters.GetTotalPages(totalCount),
                orderby = queryParameters.OrderBy
            }), "last", "GET"));

            if (queryParameters.HasNext(totalCount))
            {
                links.Add(new LinkDto(_urlHelper.Link(nameof(GetAll), new
                {
                    pagecount = queryParameters.PageCount,
                    page = queryParameters.Page + 1,
                    orderby = queryParameters.OrderBy
                }), "next", "GET"));
            }

            if (queryParameters.HasPrevious())
            {
                links.Add(new LinkDto(_urlHelper.Link(nameof(GetAll), new
                {
                    pagecount = queryParameters.PageCount,
                    page = queryParameters.Page - 1,
                    orderby = queryParameters.OrderBy
                }), "previous", "GET"));
            }

            return links;
        }

        public IQueryable<Product> GetAllTwo(QueryParameters queryParameters)
        {
            IQueryable<Product> _allItems = _context.Products.OrderBy(queryParameters.OrderBy,
              queryParameters.IsDescending());

            if (queryParameters.HasQuery())
            {
                _allItems = _allItems
                    .Where(x => x.Name.ToString().Contains(queryParameters.Query.ToLowerInvariant()));
            }

            return _allItems
                .Skip(queryParameters.PageCount * (queryParameters.Page - 1))
                .Take(queryParameters.PageCount);
        }

        private dynamic ExpandSingleItem(Product product)
        {
            var links = GetLinks(product.ProductId);
            item = _mapper.Map<ProductViewModel>(product);

            var resourceToReturn = item.ToDynamic() as IDictionary<string, object>;
            resourceToReturn.Add("links", links);

            return resourceToReturn;
        }

        private IEnumerable<LinkDto> GetLinks(int id)
        {
            var links = new List<LinkDto>();

            links.Add(
              new LinkDto(_urlHelper.Link(nameof(GetSingle), new { id = id }),
              "self",
              "GET"));

            links.Add(
              new LinkDto(_urlHelper.Link(nameof(Delete), new { id = id }),
              "delete",
              "DELETE"));

            links.Add(
              new LinkDto(_urlHelper.Link(nameof(Add), null),
              "create",
              "POST"));

            links.Add(
               new LinkDto(_urlHelper.Link(nameof(Update), new { id = id }),
               "update",
               "PUT"));

            return links;
        }
    }
}