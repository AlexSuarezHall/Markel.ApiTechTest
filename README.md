CompanyController<br/> <br/> 

Example GET Requests - Get Company by ID:<br/> <br/> 

https://localhost:7062/Company/1

https://localhost:7062/Company/2<br/> <br/> 

ClaimController<br/> <br/> 

Example GET Request - Get Claims by UCR<br/> <br/> 

https://localhost:7062/Claim/UCR_1

https://localhost:7062/Claim/UCR_2<br/> <br/> 

Example GET Request - Get All Claims for Company<br/> <br/> 

https://localhost:7062/Claim/GetAllClaimsForCompany/1<br/> <br/> 

https://localhost:7062/Claim/GetAllClaimsForCompany/2 <br/> <br/> 

Example PATCH Request - Update Claim<br/> <br/> 

https://localhost:7062/Claim/UpdateClaim<br/> <br/> 

Sample request: <br/>
{ <br/>
    "ucr": "UCR_1", <br/>
    "companyId": 1, <br/>
    "claimTypeId": 1, <br/>
    "claimDate": "2024-01-01", <br/>
    "lossDate": "2024-05-05", <br/>
    "assuredName": "Updated_Test_Assured_Name", <br/> 
    "incurredLoss": 0.2, <br/>
    "closed": true <br/>
}
