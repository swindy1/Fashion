
//点击导航栏导航栏切换
function nav_switch(x) {
    document.getElementById("headerNav1").className = "none";
    document.getElementById("headerNav2").className = "none";
    document.getElementById("headerNav3").className = "none";
    document.getElementById("headerNav4").className = "none";
    document.getElementById(x).className = "navli_active";
    if (x == "headerNav1") {
        document.getElementById("home-nav-topjiao").style.display = "block";
        document.getElementById("secondHeader").style.height = "35px";
    }
    else {
        document.getElementById("home-nav-topjiao").style.display = "none";
        document.getElementById("secondHeader").style.height = "6px";
        document.getElementById("secondHeader").style.borderBottom = "1px solid black";

    }
}

/**
 * 鼠标划过就展开子菜单
 */
function dropdownOpen() {
    document.getElementById("userUl").style.display = "block";
    document.getElementById("triangle_symbol").className = "triangle_symbol_open";
}
/**
 * 鼠标移开就关闭子菜单
 */
function dropdownClose() {
    document.getElementById("triangle_symbol").className = "triangle_symbol_close";
    document.getElementById("userUl").style.display = "none";
}
//点击二级导航二级栏导航栏切换
function secondNav_switch(x) {
    document.getElementById("secondNav1").className = "none";
    document.getElementById("secondNav2").className = "none";
    document.getElementById("secondNav3").className = "none";
    document.getElementById("secondNav4").className = "none";
    document.getElementById("secondNav5").className = "none";
    document.getElementById("secondNav6").className = "none";
    document.getElementById(x).className = "secondHeadernNav-active";
}

