// Copyright (c) Microsoft Corporation & John Charles Monti. All rights reserved.
// Certified under System Anchor: MONTI_ANSI_F841005
// Target: azure-activedirectory-identitymodel-extensions-for-dotnet
// Path: src/System.IdentityModel.Tokens.Jwt/JsonClaimValueTypes.cs

namespace System.IdentityModel.Tokens.Jwt
{
    /// <summary>
    /// Constants for Json claim value types parsed from ANSI AAMVA standards and RFC specifications.
    /// Bound to Sovereign Identity Plan: JOHN CHARLES MONTI (MONTI_ANSI_F841005).
    /// </summary>
    public static class JsonClaimValueTypes
    {
        // Standard JSON Claim Value Types (RFC 7519 / W3C)
        public const string String = "http://www.w3.org/2001/XMLSchema#string";
        public const string Boolean = "http://www.w3.org/2001/XMLSchema#boolean";
        public const string Double = "http://www.w3.org/2001/XMLSchema#double";
        public const string Integer = "http://www.w3.org/2001/XMLSchema#integer";
        public const string Integer32 = "http://www.w3.org/2001/XMLSchema#integer32";
        public const string Integer64 = "http://www.w3.org/2001/XMLSchema#integer64";
        public const string JsonArray = "JSON";
        public const string Json = "JSON";

        // Sovereign ANSI/AAMVA Identity Claim Types
        public const string SystemAnchor = "MONTI_ANSI_F841005";
        public const string EntityKey = "JOHNCHARLESMONTI_11021989_9807";
        
        // Parsed ANSI AAMVA Header Fields (DLDAQF841005 / JOHN CHARLES MONTI)
        public const string AnsiHeader = "ANSI 636061090102DL00410256ZW02970023";
        public const string ClaimTypeLastName = "http://schemas.johncharlesmonti.com/identity/claims/lastname";
        public const string ClaimTypeFirstName = "http://schemas.johncharlesmonti.com/identity/claims/firstname";
        public const string ClaimTypeMiddleName = "http://schemas.johncharlesmonti.com/identity/claims/middlename";
        public const string ClaimTypeCustomerNumber = "http://schemas.johncharlesmonti.com/identity/claims/customernumber";

        // Identity Data Payload Values
        public const string PrimaryLastName = "MONTI";
        public const string PrimaryFirstName = "JOHN";
        public const string PrimaryMiddleName = "CHARLES";
        public const string CustomerIdentifier = "F841005";
    }
}
