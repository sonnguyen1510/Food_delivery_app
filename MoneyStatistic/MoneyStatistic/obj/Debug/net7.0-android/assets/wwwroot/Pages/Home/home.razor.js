// Function to adjust container height
function adjustContainerHeight() {
    const container = document.querySelector('.transaction-list-container');
    const newHeight = window.innerHeight; // Get the current window height

    // Update the container's height
    container.style.height = newHeight + 'px';
}

// Initial adjustment when the page loads
adjustContainerHeight();

// Listen for window resize events to adjust the container height
window.addEventListener('resize', adjustContainerHeight);