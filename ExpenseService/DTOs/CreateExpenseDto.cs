﻿namespace ExpenseService.DTOs
{
    public class CreateExpenseDto
    {

        public int ExpenseCategoryId { get; set; }
        public string? Description { get; set; }
        public Decimal Amount { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int AccountId { get; set; }
    }
}
