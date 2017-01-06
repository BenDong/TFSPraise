function setMenuActive(id) {
    var menu_ele = document.getElementById(id);
    if (menu_ele) {
        menu_ele.className = "active";
    }
}