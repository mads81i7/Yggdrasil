using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Yggdrasil.Models
{
    public enum UserTypes { Admin, Courier, Customer, }

    public class User
    {
        public int ID { get; set; }

        [BindProperty, Required(ErrorMessage = "{0} skal udfyldes"), Display(Name = "Brugertype")]
        public UserTypes UserType { get; set; }

        [BindProperty, Required(ErrorMessage = "{0} skal udfyldes"), Display(Name = "Fulde navn")]
        public string FullName { get; set; }

        [BindProperty, Required(ErrorMessage = "{0} skal udfyldes"), EmailAddress(ErrorMessage = "Indtast en gyldig e-mail-adresse"), Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [BindProperty, Required(ErrorMessage = "{0} skal udfyldes"), DataType(DataType.Date), Display(Name = "Fødselsdato")]
        public DateTime BirthDate { get; set; }

        [BindProperty, Required(ErrorMessage = "{0} skal udfyldes"), DataType(DataType.Password), Display(Name = "Adgangskode"), MinLength(6, ErrorMessage = "Adgangskoden skal være på minimum 6 tegn.")]
        public string Password { get; set; }

        [BindProperty, Required(ErrorMessage = "{0} skal udfyldes"), DataType(DataType.Password), Display(Name = "Gentag adgangskode"), Compare(nameof(Password), ErrorMessage = "Adgangskoderne er ikke ens.")]
        public string Password2 { get; set; }

        [BindProperty, Required(ErrorMessage = "{0} skal udfyldes"), DataType(DataType.Password), Display(Name = "Adgangskode")]
        public string PasswordCheck { get; set; }

        [BindProperty, Required(ErrorMessage = "{0} skal udfyldes"), Display(Name = "Adresse (1. linje")]
        public string AddressLine1 { get; set; }

        [BindProperty, Display(Name = "Adresse (2. linje)")]
        public string AddressLine2 { get; set; }

        [BindProperty, Required(ErrorMessage = "{0} skal udfyldes"), DataType(DataType.PostalCode), Display(Name = "Postnummer"), Range(1050, 9990, ErrorMessage = "Indtast et gyldigt dansk postnummer.")]
        public int PostalCode { get; set; }

        [BindProperty, Required(ErrorMessage = "{0} skal udfyldes"), Display(Name = "By")]
        public string City { get; set; }

        [BindProperty, Required(ErrorMessage = "{0} skal udfyldes"), DataType(DataType.PhoneNumber), Display(Name = "Telefonnummer"), MinLength(8, ErrorMessage = "Indtast et gyldigt dansk telefonnummer."), MaxLength(8, ErrorMessage = "Indtast et gyldigt dansk telefonnummer.")]
        public string PhoneNo { get; set; }

        public List<Order> UserOrders { get; set; }

        public User()
        {
            UserOrders = new List<Order>();
        }
    }
}
