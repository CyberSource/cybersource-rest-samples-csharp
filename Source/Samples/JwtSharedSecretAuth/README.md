# JWT Authentication with Shared Secret (HS256)

## Why Migrate from HTTP Signature?

**HTTP Signature authentication is being deprecated.** JWT with Shared Secret is the recommended replacement because:

1. **Same credentials** — Uses the same `merchantKeyId` and `merchantsecretKey` you already have for HTTP Signature. No new credentials needed.
2. **Enables MLE** — Message Level Encryption (MLE) requires JWT authentication. HTTP Signature does not support MLE.
3. **Minimal code change** — Only two properties need to change in your configuration.

## Migration from HTTP Signature

### Before (HTTP Signature)

```csharp
_configurationDictionary.Add("authenticationType", "HTTP_SIGNATURE");
_configurationDictionary.Add("merchantID", "your_merchant_id");
_configurationDictionary.Add("merchantKeyId", "your_key_id");
_configurationDictionary.Add("merchantsecretKey", "your_shared_secret");
```

### After (JWT with Shared Secret)

```csharp
_configurationDictionary.Add("authenticationType", "JWT");              // changed
_configurationDictionary.Add("jwtKeyType", "SHARED_SECRET");            // added
_configurationDictionary.Add("merchantID", "your_merchant_id");
_configurationDictionary.Add("merchantKeyId", "your_key_id");           // same as before
_configurationDictionary.Add("merchantsecretKey", "your_shared_secret"); // same as before
```

That's it. The `merchantKeyId` and `merchantsecretKey` values remain exactly the same.

## Samples in This Folder

| Sample | Description |
|---|---|
| [SimpleAuthorizationWithJwtSharedSecret.cs](SimpleAuthorizationWithJwtSharedSecret.cs) | Basic payment authorization using JWT + Shared Secret — drop-in replacement for HTTP Signature |
| [MLEPaymentWithJwtSharedSecret.cs](MLEPaymentWithJwtSharedSecret.cs) | Payment authorization with MLE enabled — the main benefit of migrating to JWT |

## Configuration

Configuration is defined in [`Source/JwtSharedSecretConfiguration.cs`](../../../Source/JwtSharedSecretConfiguration.cs):

- `GetMerchantDetails()` — JWT + Shared Secret (no MLE)
- `GetMerchantDetailsWithMLE()` — JWT + Shared Secret + MLE enabled

## MLE Certificate

When using MLE with Shared Secret credentials, the MLE public certificate must be provided separately via the `mleForRequestPublicCertPath` property (since there is no P12 file to auto-extract it from).

Download the MLE public certificate from the CyberSource Business Center:

- **Test**: https://businesscentertest.cybersource.com/ebc2
- **Production**: https://businesscenter.cybersource.com/ebc2

## Comparison of Authentication Types

| Feature | HTTP Signature | JWT with P12 | JWT with Shared Secret |
|---|---|---|---|
| Algorithm | HMAC-SHA256 | RS256 (asymmetric) | HS256 (symmetric) |
| Credentials | Key ID + Shared Secret | P12 certificate file | Key ID + Shared Secret |
| MLE Support | No | Yes | Yes |
| Status | **Deprecated** | Active | **Recommended for migration** |
