//自己实现的一些跟登录有关的函数或变量
//注意：1.引用本js需要引用jquery包

//本函数根据用户是否登录成功来设置导航栏的用户登录或未登录状态
//判断用户是否已经登录，如果已经登录就用户登录信息块(block)，并且显示用户头像， 
//如果未登录，就隐藏登录信息，并且显示注册和登录的信息块(block)
//参数：loginYes代表用户登录状态，1为以登录
//             loginBlock用户登录信息块的id，当用户登录成功时显示
//             unLoginBlock用户未登录信息块的id，当用户未登录时显示
//             img_touXiangId用户头像元素的Id
//             img_touXiangIdUrl用户头像的url地址
//用于页面：_Layout.cshtml
function isLoginDisplay(loginYes, loginBlock, unLoginBlock, img_touXiangId, img_touXiangIdUrl) {
    alert();
    if (loginYes == "1") {
        
        document.getElementById(loginBlock).style.display = "block";
        document.getElementById(unLoginBlock).style.display = "none";
        $(img_touXiang).attr('src', img_touXiangIdUrl);//显示个人头像
    }
    else {
        document.getElementById(unLoginBlock).style.display = "block";
        document.getElementById(loginBlock).style.display = "none";
    }
}