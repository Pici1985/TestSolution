function triangleClick(id) {
        
    const regex = /([a-zA-Z]+)(\d+)/;
    const matches = id.match(regex);

    let item = {
        row : matches[1],
        column : parseInt(matches[2])
    }
    
    clearCurrentTriangle();

    setCurrentTriangle(item.row, item.column);

    fetchTriangle(item);    
}

function getCharacterByIndex(index) {
    const charCodeA = 'a'.charCodeAt(0); // Get the ASCII code for 'a'
    const charCodeZ = 'z'.charCodeAt(0); // Get the ASCII code for 'z'
    const numLetters = charCodeZ - charCodeA + 1; // Number of letters in the alphabet
  
    // Calculate the corresponding character based on the index
    const charIndex = (index % numLetters) + charCodeA;
    const character = String.fromCharCode(charIndex);
  
    return character;
}

function generateMatrix(){
    let rows = document.getElementById("rows").value;
    let cols = document.getElementById("cols").value;

    let matrix = document.getElementById("matrix1");

    if(rows > 26){
        alert("Maximum number of rows is 26!");
        return;
    }

    if(cols < 1){
        alert("Minimum number of columns is 1!");
        return;
    }

    for(let j = 0; j < rows; j++){
        let row = document.createElement("div");
        row.classList.add("row");
                       
        for(let i = 0; i < cols; i++){  
            
            let mult1 = i + 1;
            let mult2 = i + 2;
            
            let square = document.createElement("div");
            square.classList.add("square");

            square.innerHTML = `
                <div class="boxA" id="${getCharacterByIndex(i)}${j}">
                    <span id="${getCharacterByIndex(j)}${i + mult2 }" 
                          onclick="triangleClick(id)" 
                          class="spanA">${getCharacterByIndex(j)}${i + mult2 }
                    </span>
                </div>
                <div class="boxB" id="${getCharacterByIndex(i)}${j}">
                    <span id="${getCharacterByIndex(j)}${i + mult1 }" 
                          onclick="triangleClick(id)" 
                          class="spanB">${getCharacterByIndex(j)}${i + mult1 }
                    </span>
                </div>
            `;
            
            row.appendChild(square);
        } 

        matrix.appendChild(row);
    }
}

function getTriangle(){
    let triangle = getTriangleInputs();
    
    fetch('https://localhost:7276/coordinates', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type':'application/json; charset=utf-8',
            'Access-Control-Allow-Origin': '*',
            'accept': '*/*'
        },
        body: JSON.stringify(triangle),
    }).then((response) => {
        if(!response.ok){
            throw new Error('Please enter valid coordinates!');
        }
        return response.json();
    })
    .then((data) => {
        clearDisplayTriangle();
        clearHighlightTriangle();

        if(data.column % 2 == 0){
            let span1 = document.getElementById("displaySpanA");
            span1.innerHTML = `${data.row}${data.column} `;
        } else {
            let span2 = document.getElementById("displaySpanB");
            span2.innerHTML = `${data.row}${data.column} `;
        }   
        highlightTriangle(data.row, data.column); 
    })
    .catch(error => {
        alert(error);
    });    
}

function getTriangleInputs(){
    let ay = document.getElementById("Ay").value;
    let ax = document.getElementById("Ax").value;
    let by = document.getElementById("By").value;
    let bx = document.getElementById("Bx").value;
    let cy = document.getElementById("Cy").value;
    let cx = document.getElementById("Cx").value;

    let triangle = {
        a : {
            y : ay,
            x : ax
        },
        b : {
            y : by,
            x : bx
        },
        c : {
            y : cy,
            x : cx
        }
    }

    return triangle;
}

function clearDisplayTriangle(){
    let span1 = document.getElementById("displaySpanA");
    let span2 = document.getElementById("displaySpanB");

    span1.innerHTML = "";
    span2.innerHTML = "";
}

function clearCurrentTriangle(){
    let currentTriangle = document.getElementById("currentTriangle");
    currentTriangle.innerHTML = "";
}

function highlightTriangle(row, column){
    let idToHighlight = `${row}${column}`;
        
    document.getElementById(idToHighlight).classList.add("highlight");
    document.getElementById(idToHighlight).parentElement.classList.add("highlight-alt")
}

function clearHighlightTriangle(){
    var highlight = document.getElementsByClassName("highlight");

    if(highlight.length == 0){
        return;
    } else {
        highlight[0].parentElement.classList.remove("highlight-alt");
        highlight[0].classList.remove("highlight");   
    }
}

function deleteMatrix(){
    let matrix = document.getElementById("matrix1");
    matrix.innerHTML = "";  
}

function setCurrentTriangle(row, column){
    let idToHighlight = ` ${row}${column}`;
    let currentTriangle = document.getElementById("currentTriangle");
    currentTriangle.innerHTML = idToHighlight;
}

function fetchTriangle(item){
    fetch('https://localhost:7276/triangleid', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type':'application/json; charset=utf-8',
            'Access-Control-Allow-Origin': '*',
            'accept': '*/*'
        },
        body: JSON.stringify(item),
    }).then(response => response.json())
    .then((data) => {
        let coordinates = document.getElementById("coordinates");
        
        let responeItem = document.createElement("div");
        responeItem.classList.add("responeItem");
        responeItem.innerHTML = `
            <p>
                <span class="current-triangle-span">${item.row}${item.column} </span> 
                A: ${data.a.y},${data.a.x} B: ${data.b.y},${data.b.x} C: ${data.c.y},${data.c.x}
            </p>          
        `;

        coordinates.appendChild(responeItem);
    });
}