class Posting extends HTMLElement {
    constructor() {
        super();
        // Load the external HTML file containing the template
        fetch('../webcomponents/posting.html')
            .then(response => response.text())
            .then(html => {
                // Create a temporary DOM to parse the HTML
                const template = document.createElement('template');
                template.innerHTML = html;
                // console.log(html);
                // Clone the content of the template into the shadow DOM
                const content = template.content.querySelector('#posting-template').content.cloneNode(true);
                // console.log(content);
                this.append(content);
            })
            .catch(error => console.error('Error loading navbar template:', error));
    }
}

// Define the custom element
customElements.define('posting-thumb', Posting);
