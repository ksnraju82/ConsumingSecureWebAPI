# ConsumingSecureWebAPI
WebJet
First, i assumed to develop async mvc to consume the webapi, upon errors i realised this webAPI is not supporing async webAPI. 
Then, i followed traditional approach to develop MVC application to consume it.
The response is quite tricky, i developed a list movie model to consume the response, but the response was in movie array format. So , i got to change
my logic to consume movies array and forward the same to view.
Since, there are two repositories, i have maintained seperate reusable class for all the webAPI requests (Resusability).
As per the exercise i have only included functionality to display all the items of the database and filter as per the ID.


Due to the vast length of POSTER field, the design is quite disturbed, but i have urlshortner project already developed and is in my github 
projects, i can implement the same to improve the UI.


I have defined seperate class called as "GetAPIResponse" for reusability, the class is defined as static, for the test case to work we can
define it as normal class and execute the test cases.
