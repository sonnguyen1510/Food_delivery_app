window.addEventListener("resize", function () {
    adjustComponentHeight();
});

function adjustComponentHeight() {
    const component = document.querySelector(".transaction-list-container"); // Replace "myComponent" with the actual element ID
    if (component) {
        component.style.height = window.innerHeight + "px";
    }
}

function registerWindowResizeHandler() {
    adjustComponentHeight();
}