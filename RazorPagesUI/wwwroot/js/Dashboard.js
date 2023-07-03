function showMobile() {

    let openSideBar = document.querySelector("#side");
    let hamburger = document.querySelector(".button-container").children;
    if (openSideBar.style.left < "0px") {
        openSideBar.style.cssText = `
            left: 0px;
            transition: 1s;
        `

        //turn sidebar hamburger into a X
        hamburger.item(0).style.cssText = `
                transform: rotate(45deg) translate(10px, 10px);
                transition: 1s
            `
        hamburger.item(1).style.cssText = `
                transform: rotate(-45deg) ;
                transition: 1s;
            `
    } else {
        openSideBar.style.cssText = `
            left: -13em;
            transition: 1s
        `

        //turn sidebar X into hamburger
        //hamburger.item(2).style.display = "block"
        hamburger.item(0).style.cssText = `
                transform: rotate(0deg);
                transition: 1s
            `
        hamburger.item(1).style.cssText = `
                transform: rotate(0deg);
                transition: 1s;
            `

    }
}

document.querySelector(".button-container").addEventListener("click", function () {
    showMobile()
})