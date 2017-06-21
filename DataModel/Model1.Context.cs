﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class INSTITUTERECORDEntities : DbContext
    {
        public INSTITUTERECORDEntities()
            : base("name=INSTITUTERECORDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<StudentDetail> StudentDetails { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual ObjectResult<Nullable<int>> AddNewStudentDetails(string firstName, string lastName, string suburb, string emailid, string phoneNumber, Nullable<int> enrolledHours)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var suburbParameter = suburb != null ?
                new ObjectParameter("Suburb", suburb) :
                new ObjectParameter("Suburb", typeof(string));
    
            var emailidParameter = emailid != null ?
                new ObjectParameter("Emailid", emailid) :
                new ObjectParameter("Emailid", typeof(string));
    
            var phoneNumberParameter = phoneNumber != null ?
                new ObjectParameter("PhoneNumber", phoneNumber) :
                new ObjectParameter("PhoneNumber", typeof(string));
    
            var enrolledHoursParameter = enrolledHours.HasValue ?
                new ObjectParameter("EnrolledHours", enrolledHours) :
                new ObjectParameter("EnrolledHours", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("AddNewStudentDetails", firstNameParameter, lastNameParameter, suburbParameter, emailidParameter, phoneNumberParameter, enrolledHoursParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> AddPaymentDetails(Nullable<long> studentId, string amountToPay, string paid, string pendingAmount)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(long));
    
            var amountToPayParameter = amountToPay != null ?
                new ObjectParameter("AmountToPay", amountToPay) :
                new ObjectParameter("AmountToPay", typeof(string));
    
            var paidParameter = paid != null ?
                new ObjectParameter("Paid", paid) :
                new ObjectParameter("Paid", typeof(string));
    
            var pendingAmountParameter = pendingAmount != null ?
                new ObjectParameter("PendingAmount", pendingAmount) :
                new ObjectParameter("PendingAmount", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("AddPaymentDetails", studentIdParameter, amountToPayParameter, paidParameter, pendingAmountParameter);
        }
    
        public virtual ObjectResult<GenerateToken_Result> GenerateToken(string authToken, Nullable<int> userId, Nullable<System.DateTime> issuedOn, Nullable<System.DateTime> expiresOn)
        {
            var authTokenParameter = authToken != null ?
                new ObjectParameter("AuthToken", authToken) :
                new ObjectParameter("AuthToken", typeof(string));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var issuedOnParameter = issuedOn.HasValue ?
                new ObjectParameter("IssuedOn", issuedOn) :
                new ObjectParameter("IssuedOn", typeof(System.DateTime));
    
            var expiresOnParameter = expiresOn.HasValue ?
                new ObjectParameter("ExpiresOn", expiresOn) :
                new ObjectParameter("ExpiresOn", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GenerateToken_Result>("GenerateToken", authTokenParameter, userIdParameter, issuedOnParameter, expiresOnParameter);
        }
    
        public virtual ObjectResult<GetStudentDetails_Result> GetStudentDetails(string firstName, string lastName, string phoneNumber)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var phoneNumberParameter = phoneNumber != null ?
                new ObjectParameter("PhoneNumber", phoneNumber) :
                new ObjectParameter("PhoneNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentDetails_Result>("GetStudentDetails", firstNameParameter, lastNameParameter, phoneNumberParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_DeleteTokens(Nullable<long> tokenId, Nullable<long> userId, string idType)
        {
            var tokenIdParameter = tokenId.HasValue ?
                new ObjectParameter("TokenId", tokenId) :
                new ObjectParameter("TokenId", typeof(long));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(long));
    
            var idTypeParameter = idType != null ?
                new ObjectParameter("IdType", idType) :
                new ObjectParameter("IdType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_DeleteTokens", tokenIdParameter, userIdParameter, idTypeParameter);
        }
    
        public virtual ObjectResult<Nullable<long>> sp_ValidateToken(string tokenStr, Nullable<int> expiryseconds)
        {
            var tokenStrParameter = tokenStr != null ?
                new ObjectParameter("TokenStr", tokenStr) :
                new ObjectParameter("TokenStr", typeof(string));
    
            var expirysecondsParameter = expiryseconds.HasValue ?
                new ObjectParameter("Expiryseconds", expiryseconds) :
                new ObjectParameter("Expiryseconds", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("sp_ValidateToken", tokenStrParameter, expirysecondsParameter);
        }
    
        public virtual ObjectResult<Nullable<long>> ValidateUser(string userName, string password)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("ValidateUser", userNameParameter, passwordParameter);
        }
    }
}
