function solve() {
    const fields = document.querySelectorAll('#container input');
    const addButton = document.querySelector('#container button');
    const adoption = document.querySelector('#adoption ul');
    const adopted = document.querySelector('#adopted ul');

    const input = {
        name: fields[0],
        age: fields[1],
        kind: fields[2],
        owner: fields[3],
    }

    addButton.addEventListener('click', (event) => {
        event.preventDefault();

        const name = input.name.value.trim();
        const age = Number(input.age.value.trim());
        const kind = input.kind.value.trim();
        const owner = input.owner.value.trim();

        if (name == '' || input.age.value.trim() == '' || Number.isNaN(age) || kind == '' || owner == '') {
            return;
        }

        //`{name} is a {years} year old {kind}`
        const contactBtn = element('button', {}, 'Contact with owner');

        const pet = element('li', {},
            element('p', {},
                element('strong', {}, name),
                ' is a ',
                element('strong', {}, age),
                ' year old ',
                element('strong', {}, kind)
            ),
            element('span', {}, `Owner: ${owner}`),
            contactBtn
        );

        contactBtn.addEventListener('click', contact);

        adoption.appendChild(pet);

        input.name.value = '';
        input.age.value = '';
        input.kind.value = '';
        input.owner.value = '';

        function contact() {
            const confInput = element('input', { placeholder: 'Enter your names' });
            const confBtn = element('button', {}, 'Yes! I take it!');
            const confDiv = element('div', {},
                confInput,
                confBtn
            );

            confBtn.addEventListener('click', adopt.bind(null, confInput, pet));

            contactBtn.remove();
            pet.appendChild(confDiv);
        }
    })



    function adopt(input, pet) {
        const newOwner = input.value.trim();

        if (newOwner == '') {
            return;
        }
        const checkBtn = element('button', {}, 'Checked');
        checkBtn.addEventListener('click', checked.bind(null, pet));

        pet.querySelector('div').remove();
        pet.appendChild(checkBtn);

        pet.querySelector('span').textContent = `New Owner: ${newOwner}`;

        adopted.appendChild(pet);
    }

    function checked(pet) {
        pet.remove();
    }


    function element(type, attr, ...content) {
        const element = document.createElement(type);

        for (let prop in attr) {
            element[prop] = attr[prop];
        }
        for (let item of content) {
            if (typeof item == 'string' || typeof item == 'number') {
                item = document.createTextNode(item);
            }

            element.appendChild(item)
        }

        return element;
    }

}

