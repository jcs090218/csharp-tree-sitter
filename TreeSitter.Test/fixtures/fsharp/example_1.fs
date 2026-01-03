// Define a new record type
type ContactCard = { 
    Name : string 
    Phone : string 
    Verified : bool 
}

// Instantiate a record
let contact1 = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

// Use "copy-and-update" to create a new record from an existing one
let contact2 = { contact1 with Phone = "(206) 555-0112"; Verified = true }

// Function to process a record
let showContactCard (c: ContactCard) = 
    c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

printfn $"Alf's updated contact card: {showContactCard contact2}"
