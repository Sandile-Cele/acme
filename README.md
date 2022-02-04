#ACME research

# Introduction

Following document will explain what methodologies, DevOps ,and frameworks are and why they are important. This document has been written in a way to ensure that individuals without a solid background in computer science are able to comprehend the ideas presented, with no difficulty.

# Development methodology

### ![](RackMultipart20220204-4-pv4k0h_html_b687c5fef31e5263.jpg)

_SCRUM process: https://www.crystalloids.com/about-us/how-we-work_

###

SCRUM uses the agile philosophy, so it has all the great values and principles of Agile.

### Using SCRUM could lead to higher revenue

This is because though out the development process all teams are going to receive feedback and constructive criticism. This means that throughout the development life cycle other members are going to be able to spot your flaws since your part of the project will be viewed by other members from another perspective. This will give you time to rectify your flaws. On inception day ACME will release a well-polished project that does not require major or frequent updates saving you money (Petrova, 2019)! New users are going to have a great first impression that means they might visit frequently, or even suggest the service to others, meaning more revenue.

### More manageable project

The large project is going to be broken down into smaller, more manageable &quot;blocks&quot;. Each block of the project will be finished in about 2-4 weeks as you can see in the illustration. This is called a sprint. You will be able to watch the website grow and during the development process you will be able to see your dreams turn into reality, if not you can ask for modifications. You can put your mind at ease knowing that you will be getting your vision even if you were not able to clearly articulate it at the beginning or forgot about other features you want to incorporate (Petrova, 2019).

### Competitive final product

Get a competitive ecommerce website at inception. When using the waterfall approach all the requirements would be place upfront and through-out the development life cycle you would be following a plan. So, if someone comes up with a good idea, it cannot not be incorporated because it was not on the plan. But SCRUM encourages change so you can rest assured that at inception you will be releasing a website with the latest security features, payment methods e.g., OZOW, and can keep up with that latest design trends (Petrova, 2019).

###

### Beta testing

Get your website out to the public before it is even done. At the end of each sprint each project block could be released to the public for a plethora of reasons to help ACME as a business. The first block to be released could be just the ability to view the products. This means that in the marketing material links and screenshots of the website could be placed. This allows potential future customers to be beta testers for the website. During this phase, all user experience data could be collected and update the website while it is still under development. This could be people saying they do not like the colour scheme, website not working on some browsers or website not translating well on mobile devices. During this process you will be also building brand awareness (Agilest, 2021)!

# Implementing development and operations (DevOps)

# ![](RackMultipart20220204-4-pv4k0h_html_51350934b1da8912.png)

_DevOps without DevOps Tools__: https://medium.com/faun/devops-without-devops-tools-3f1deb451b1c_

DevOps is a combination of two terms Development and Operations. As you can see in the &quot;DevOps without DevOps Tools&quot; illustration, developers are responsible for planning the project, coding it, building, and testing. And the operation team is responsible for releasing the project, deploying, put it into operation and monitor it when it is in production.

Traditionally these teams work separately so developers would just make the software, once they are done, they would ship it off to the operation team to deploy it. The problem with this approach is that the development environment (this could be a developer&#39;s laptop) and the production environment is not the same.

When the project was deployed to the production environment it would not perform as well as in the development environment so websites would get many issues such as performance or sometimes not running at all. Releases would also take longer.

This is where DevOps comes in. DevOps encourages collaborations between developers and operators that will result in better communication between the two (Courtemanche, 2021). With this collaboration developers can test their code in realistic production environment giving them time to fix errors and give them the opportunity to enhance the performance of the website.

What does this mean for ACME? This website will be built faster, have a smother deployment process, save time and money.

# Frameworks

![](RackMultipart20220204-4-pv4k0h_html_ec7e5fb5d8103cc.png)

_ITIL: https://lerablog.org/business/certification/itil-standard-management-practices-and-certification_

I recommend the use of the ITIL framework.

ITIL stands for Information Technology Infrastructure Library. ITIL is a set of guidelines with instructions for how ACME can provide the best service possible. As you can see in the ITIL illustration there are 5 categories: strategy, design, transition, operation, and continual improvement. Each of these categories contain a list of specific processes.

As mentioned above ITIL is a set of guidelines. These are established guidelines that provide the best IT practices so that the IT service of ACME can be in alignment with its customers and the needs of the business.

If ACME decides to incorporate ITIL then it will benefit in several ways. There will be a stronger alignment between IT and the business. You can greatly improve the service delivery of ACME products and drastically improve customer satisfaction. You will be able to reduce the costs through improved utilization of resources. You will be better able to visualise the costs of assets and IT. You can better manage the risk of the business and minimize failure.

# Description of the prototype

To run the website just click on this link: [https://19013083acmeinc.azurewebsites.net/](https://19013083acmeinc.azurewebsites.net/)

There are three types of users in this website. Unregistered users, registered users, and admins.

### Storing information

The ACME website needed a placed to store information permanently, and to store information you need a database. There are different types of databases, but I chose a SQL database hosted by azure. A SQL database, to simply put a database that uses many tables to store information of one type of thing (it can be any noun). Example it could be customer, shopping cart or administrator. And all these tables have relationships e.g., a customer can put a product into a shopping cart. For ACME using a SQL database means the website will be faster because using SQL queries is quick and efficient (Java point, 2021).

Azure is Microsoft&#39;s cloud platform, and this is where the website and the SQL database will be hosted. For ACME this means that the website will almost never go down because of how reliable Microsoft is and the website will be able to scale up or down depending on the number of visits. This means that ACME will be able to handle a lot of customers during busy times and pay less when there are no users visiting the website.

### Unregistered users

Unregistered users are users without an account. These users can browse for products and see details of it. These users also can search for products, and they do not have to enter the full specific name e.g., if they search for &quot;bo&quot; results of books will show up.

### Registered users

For anyone to create an account they can click on &quot;Accounts&quot; on the top right of the website then click &quot;Sign up&quot; then enter their credentials. As a security measure the password is hashed then stored in the database. Hashing is the process of transforming a string (in this case a password) into another unreadable string. This is one of the methods we have employed to improve the security of ACME&#39;s customers.

Once the account is created the user can now purchase products. Once a product is purchased, users will be able to view their list of orders they made.

To login, the registered user must enter their email address and password. The reason for restricting users to and email address it because it is easier to remember then a unique username. These are the small things we think about to improve the customer experience.

###

### Administrator

For an administrator to create an account they can also click on &quot;Accounts&quot; on the top right, then click admin sign then enter details. The account button will always be available for uses to login or logout; this is to make the process easier.

Admins can view all the orders that customers have made. Once the order has been processed, they can delete the order. In the future this will be updated to have a status column, rather than completely removing the order from the database.

Admins can also view a chart to visually see the trend of product categories that are ordered. This information could be used to decide how much stock should be bought for certain categories.

# Conclusion

We hope this document helped you to better understand how we will improve performance; why we choose the Scrum methodology and how it improves your business; the use of DevOps and why it is important; and finally, why we choose the ITIL framework.

#

# References

Agilest, 2021. _Why Does Scrum Work?._ [Online]
 Available at: https://www.agilest.org/scrum/why-does-scrum-work/
 [Accessed 6 July 2021].

Anon., 2021. _What Is Scrum Methodology? &amp; Scrum Project Management._ [Online]
 Available at: https://www.digite.com/agile/scrum-methodology
 [Accessed 6 July 2021].

Courtemanche, M., 2021. _What is DevOps? The ultimate guide._ [Online]
 Available at: https://searchitoperations.techtarget.com/definition/DevOps
 [Accessed 7 July 2021].

Henry Payne , 2012. _5 WAYS TO WRITE FASTER C#._ [Online]
 Available at: https://www.sandfield.co.nz/news/whats-going-on/191/5-ways-to-write-faster-c
 [Accessed 7 July 2021].

Java point, 2021. _Advantages of SQL._ [Online]
 Available at: https://www.javatpoint.com/dbms-advantage-of-sql
 [Accessed 6 July 2021].

Petrova, S., 2019. _Adopting Agile: The Latest Reports About The Popular Mindset._ [Online]
 Available at: https://adevait.com/blog/remote-work/adopting-agile-the-latest-reports-about-the-popular-mindset
 [Accessed 6 July 2021].

Scrum.org, 2021. _WHAT IS SCRUM?._ [Online]
 Available at: https://www.crystalloids.com/about-us/how-we-work
 [Accessed 7 July 2021].

Stobierski, T., 2021. _Agile vs. Scrum: What&#39;s the Difference?._ [Online]
 Available at: https://www.northeastern.edu/graduate/blog/agile-vs-scrum/
 [Accessed 6 July 2021].

##
