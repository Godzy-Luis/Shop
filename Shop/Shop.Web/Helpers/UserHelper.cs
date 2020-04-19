﻿using Microsoft.AspNetCore.Identity;
using Shop.Web.Data.Entities;
using Shop.Web.Models;
using System.Threading.Tasks;

namespace Shop.Web.Helpers
{
	public class UserHelper : IUserHelper
	{
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;

		public UserHelper(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		public async Task<IdentityResult> AddUserAsync(User user, string password)
		{
			return await this.userManager.CreateAsync(user, password);
		}

		public async Task<User> GetUserByEmailAsync(string email)
		{
			return await this.userManager.FindByEmailAsync(email);
		}

		public async Task<SignInResult> LoginAsync(LoginViewModel model)
		{
			return await this.signInManager.PasswordSignInAsync(
				model.Username,
				model.Password,
				model.RememberMe,
				false);
		}

		public async Task LogoutAsync()
		{
			await this.signInManager.SignOutAsync();
		}
	}
}
