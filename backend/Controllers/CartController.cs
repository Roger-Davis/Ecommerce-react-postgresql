using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Models;
using backend.DTOs.Cart;
using backend.Services;
using backend.DTOs.Category;
using backend.DTOs.CartItem;
using backend.Services.Impl;

namespace backend.Controllers
{
    [Route("api/v1/[controller]s")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<CartDTO>>>> GetSingle(int id)
        {
            return Ok(await _cartService.GetCartById(id));
        }

        [HttpGet("{userId}/cart")]
        public async Task<ActionResult<ServiceResponse<List<CartDTO>>>> GetCartByUserId(int userId)
        {
            return Ok(await _cartService.GetCartByUserId(userId));
        }

        // [HttpPost()]
        // public async Task<ActionResult<ServiceResponse<List<CartDTO>>>> AddProductToCart2(int userId, int productId)
        // {
        //     return Ok(await _cartService.AddProductToCart2(userId,productId));
        // }
        [HttpPost()]
        public async Task<ActionResult<ServiceResponse<List<CartDTO>>>> AddProductToCart(AddCartDTO newCart)
        {
            return Ok(await _cartService.AddProductToCart(newCart));
        }
        
    }



}