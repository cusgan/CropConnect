function loadCommonhead(){
    fetch('../webcomponents/common-head.html')
        .then(response => response.text())
        .then(html => {
            // Create a temporary DOM to parse the HTML
            const template = document.createElement('template');
            template.innerHTML = html;
            // console.log(html);
            // Clone the content of the template into the shadow DOM
            const content = template.content.querySelector('#head-template').content.cloneNode(true);
            // console.log(content);
            const head = document.head;
            head.append(content);

            const tailwindScript = document.createElement('script');
            tailwindScript.src = "https://cdn.tailwindcss.com";
            document.body.appendChild(tailwindScript);
            document.body.offsetHeight;

        })
        .catch(error => console.error('Error loading head template:', error));
    
}
// loadCommonhead();

class NavBar extends HTMLElement {
    constructor() {
        super();
        // Load the external HTML file containing the template
        fetch('../webcomponents/common-navbar.html')
            .then(response => response.text())
            .then(html => {
                // Create a temporary DOM to parse the HTML
                const template = document.createElement('template');
                template.innerHTML = html;
                // console.log(html);
                // Clone the content of the template into the shadow DOM
                const content = template.content.querySelector('#navbar-template').content.cloneNode(true);
                // console.log(content);
                this.append(content);
            })
            .catch(error => console.error('Error loading navbar template:', error));
    }
}

// Define the custom element
customElements.define('nav-bar', NavBar);

class NavBarNoPlus extends HTMLElement {
    constructor() {
        super();
        // Load the external HTML file containing the template
        fetch('../webcomponents/common-navbar.html')
            .then(response => response.text())
            .then(html => {
                // Create a temporary DOM to parse the HTML
                const template = document.createElement('template');
                template.innerHTML = html;
                // console.log(html);
                // Clone the content of the template into the shadow DOM
                const content = template.content.querySelector('#navbar-noplus-template').content.cloneNode(true);
                // console.log(content);
                this.append(content);
            })
            .catch(error => console.error('Error loading navbar template:', error));
    }
}

// Define the custom element
customElements.define('nav-bar-no-plus', NavBarNoPlus);

// class Empty extends HTMLElement {
//     // The browser calls this method when the element is
//     // added to the DOM.
//     connectedCallback() {
//         // Create a Date object representing the current date.
//         const now = new Date();

//         // Format the date to a human-friendly string, and set the
//         // formatted date as the text content of this element.
//         this.textContent = now.toLocaleDateString();
//     }
// }
// customElements.define('emptyelem',Empty)