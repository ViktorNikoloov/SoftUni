function encodeAndDecodeMessages() {
    document.getElementById('main').addEventListener('click', (ev) => {

        if (ev.target.textContent == 'Encode and send it') {
            const messageToEncode = document.querySelectorAll('textarea')[0].value;
            const decodeTextarea = document.querySelectorAll('textarea')[1];

            decodeTextarea.value = encodeText(messageToEncode);
            ev.target.parentNode.querySelector('textarea').value = '';

        } else if (ev.target.textContent == 'Decode and read it') {
            const messageToDecode = document.querySelectorAll('textarea')[1].value;

            ev.target.parentNode.querySelector('textarea').value = decodeText(messageToDecode);
        }
    })

    function encodeText(text) {
        let result = '';
        [...text].forEach(char => {
            let currChar = Number(char.charCodeAt(0) + 1);
            result += String.fromCharCode(currChar);
        });

        return result;
    }

    function decodeText(text) {
        let result = '';
        [...text].forEach(char => {
            let currChar = Number(char.charCodeAt(0) - 1);
            result += String.fromCharCode(currChar);
        });

        return result;
    }
}