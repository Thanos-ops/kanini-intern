# Frontend API Reference - Variable Names

## Address API Endpoints

### POST /api/user/address - Add Address
**Frontend should send:**
```javascript
const addressData = {
  type: "Home", // Required: "Home", "Work", or "Other"
  address: "123 Main Street, Apt 4B", // Required: Full address line
  city: "New York", // Required: City name
  pincode: "123456", // Required: 6-digit pincode
  isDefault: true // Optional: boolean, defaults to false
};

fetch('/api/user/address', {
  method: 'POST',
  headers: {
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${token}`
  },
  body: JSON.stringify(addressData)
});
```

### GET /api/user/address - Get Addresses
**Backend returns:**
```javascript
{
  success: true,
  message: "Success",
  data: [
    {
      id: 1,
      type: "Home",
      address: "123 Main Street, Apt 4B", // This is AddressLine in database
      city: "New York",
      pincode: "123456",
      isDefault: true
    }
  ]
}
```

### PUT /api/user/address/{id} - Update Address
**Frontend should send:**
```javascript
const updateData = {
  type: "Work",
  address: "456 Business Ave", // Maps to AddressLine in database
  city: "Brooklyn",
  pincode: "654321",
  isDefault: false
};
```

### DELETE /api/user/address/{id} - Delete Address
**No body required, just the ID in URL**

## Important Notes:

1. **Variable Name Mapping:**
   - Frontend: `address` → Backend Model: `AddressLine`
   - This mapping is handled automatically by AutoMapper

2. **Validation Rules:**
   - `type`: Must be "Home", "Work", or "Other"
   - `address`: Required, max 500 characters
   - `city`: Required, max 100 characters  
   - `pincode`: Required, exactly 6 digits
   - `isDefault`: Boolean, when true, sets all other addresses to false

3. **Authentication:**
   - All endpoints require JWT Bearer token
   - Include in Authorization header: `Bearer {token}`

4. **Response Format:**
   - Success: HTTP 200/201 with ApiResponse wrapper
   - Error: HTTP 400/404 with error message in ApiResponse

## Common Frontend Mistakes to Avoid:

❌ **Wrong variable names:**
```javascript
{
  addressLine: "123 Main St", // Wrong! Use 'address'
  zipCode: "12345",          // Wrong! Use 'pincode'
  addressType: "Home"        // Wrong! Use 'type'
}
```

✅ **Correct variable names:**
```javascript
{
  address: "123 Main St",    // Correct!
  pincode: "123456",         // Correct!
  type: "Home"               // Correct!
}
```