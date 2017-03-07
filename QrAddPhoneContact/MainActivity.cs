using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;
using Android.Provider;
using System.Collections.Generic;

namespace QrAddPhoneContact
{
    [Activity(Label = "QrAddPhoneContact", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            AddContact();
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }

        public void AddContact()
        {
            String DisplayName = "Testing";
            String MobileNumber = "0851237654";
            String email = "email@nomail.com";
            
            List<ContentProviderOperation> ops = new List<ContentProviderOperation>();

            int rawContactInsertIndex = ops.Count;

            ops.Add(ContentProviderOperation.NewInsert(Android.Provider.ContactsContract.RawContacts.ContentUri)
                 .WithValue(Android.Provider.ContactsContract.RawContacts.InterfaceConsts.AccountType, null)
                 .WithValue(Android.Provider.ContactsContract.RawContacts.InterfaceConsts.AccountName, null).Build());

            //Display Name

            ops.Add(ContentProviderOperation
                 .NewInsert(Android.Provider.ContactsContract.Data.ContentUri)
                 .WithValueBackReference(Android.Provider.ContactsContract.Data.InterfaceConsts.RawContactId, rawContactInsertIndex)
                 .WithValue(Android.Provider.ContactsContract.Data.InterfaceConsts.Mimetype, Android.Provider.ContactsContract.CommonDataKinds.StructuredName.ContentItemType)
                 .WithValue(Android.Provider.ContactsContract.CommonDataKinds.StructuredName.DisplayName, DisplayName).Build()); // Name of the person

            //mobile number

            ops.Add(ContentProviderOperation
                 .NewInsert(Android.Provider.ContactsContract.Data.ContentUri)
                 .WithValueBackReference(ContactsContract.Data.InterfaceConsts.RawContactId, rawContactInsertIndex)
                 .WithValue(Android.Provider.ContactsContract.Data.InterfaceConsts.Mimetype, Android.Provider.ContactsContract.CommonDataKinds.Phone.ContentItemType)
                 .WithValue(Android.Provider.ContactsContract.CommonDataKinds.Phone.Number, MobileNumber) // Number of the person
                 .WithValue(Android.Provider.ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Type, "mobile").Build()); // Type of mobile number

            //email Address
            ops.Add(ContentProviderOperation
                .NewInsert(ContactsContract.Data.ContentUri)
                .WithValueBackReference(ContactsContract.Data.InterfaceConsts.RawContactId, rawContactInsertIndex)
                .WithValue(Android.Provider.ContactsContract.Data.InterfaceConsts.Mimetype,ContactsContract.CommonDataKinds.Email.ContentItemType)
                .WithValue(Android.Provider.ContactsContract.CommonDataKinds.Email.Address, email).Build()); // Email Address
            //.WithValue(ContactsContract.CommonDataKinds.Email.TYPE, ContactsContract.CommonDataKinds.Email.TYPE_WORK)

            // Asking the Contact provider to create a new contact                 
            try
            {
                ContentResolver.ApplyBatch(ContactsContract.Authority, ops);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Exception: " + ex.Message, ToastLength.Long).Show();
            }
        }
    }
}

