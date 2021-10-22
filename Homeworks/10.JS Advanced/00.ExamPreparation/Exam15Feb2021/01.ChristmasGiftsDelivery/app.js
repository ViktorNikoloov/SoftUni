function solution() {
    const [gift, sent, discarded] = document.querySelectorAll('section ul');


    document.querySelector('button').addEventListener('click', addGift);



    function addGift() {
        const addValue = document.querySelector('input').value;
        document.querySelector('input').value = '';

        const liElement = element('li', addValue, 'gift');
        const sendButton = element('button', 'Send', 'sendButton');
        const discardButton = element('button', 'Discard', 'discardButton');

        liElement.appendChild(sendButton);
        liElement.appendChild(discardButton);

        sendButton.addEventListener('click', () => sendGift(addValue, liElement));
        discardButton.addEventListener('click', () => discardGift(addValue, liElement));

        gift.appendChild(liElement);

        sortGifts();
    }


    function sendGift(name, gift) {
        gift.remove();
        const liElement = element('li', name, 'gift')
        sent.appendChild(liElement);

    }

    function discardGift(name, gift) {
        gift.remove();
        const liElement = element('li', name, 'gift')
        discarded.appendChild(liElement);
    }

    function sortGifts() {
        Array
            .from(gift.children)
            .sort((a, b) => a.childNodes[0].textContent.localeCompare(b.childNodes[0].textContent))
            .forEach(g => gift.appendChild(g));

    }

    function element(type, content, className) {
        let element = document.createElement(type);
        element.textContent = content;
        if (className) {
            element.className = className;
        }
        return element;
    }
}