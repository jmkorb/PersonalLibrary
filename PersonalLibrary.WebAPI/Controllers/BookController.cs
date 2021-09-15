﻿using Microsoft.AspNet.Identity;
using PersonalLibrary.Data;
using PersonalLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonalLibrary.WebAPI.Controllers
{
    [Authorize]
    public class BookController : ApiController
    {
        private BookService CreateBookService()
        {
            var bookId = int.Parse(User.Identity.GetUserId());
            var bookService = new BookService(bookId);
            return bookService;
        }
    }
}
