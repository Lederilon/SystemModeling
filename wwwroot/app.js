function onCreate() {
    var matrixElement = document.getElementById('nodeConnection');
    var count = Number(document.getElementById('nodes').value);
    createConnectionMatrix(count, matrixElement);

    var weights = document.getElementById('weights');
    createWeightsmatrix(count, weights,[]);
  };

  function onCreate2(){
    var matrixElement = document.getElementById('procConnections');
    var count = Number(document.getElementById('nodes2').value);
    createConnectionMatrix(count, matrixElement);
  }

  function createWeightsmatrix(count, matrixElement, sorting)
    {
        for(var i = 0; i < 1 + 1; i++) {
            var tr = document.createElement('tr');
            for(var j = 0; j < count; j++) {
              var td = document.createElement('td');
              var element = document.createElement('input');
              element.setAttribute("type", "number");
              element.value = 0;
              element.width = 5;
              element.height = 5;
      
              if(i == 0)
              {
                  element.disabled = true;
                  if(i == 0)
                  {
                    element.value = j + 1;
                  }
              }
              else
              {
                element.value = sorting[j];
              }
      
              td.appendChild(element);
              tr.appendChild(td);
            }
            matrixElement.appendChild(tr);
          }  
    }
  function createConnectionMatrix(count , matrixElement)
  {
    for(var i = 0; i < count + 1; i++) {
        var tr = document.createElement('tr');
        for(var j = 0; j < count + 1; j++) {
          var td = document.createElement('td');
          var element = document.createElement('input');
          element.setAttribute("type", "number");
          element.value = 0;
          element.width = 5;
          element.height = 5;
  
          if(i == 0 || j ==0)
          {
              element.disabled = true;
              if(i == 0)
              {
                element.value = j;
              }
              if(j==0)
              {
                  element.value = i;
              }
          }
  
          td.appendChild(element);
          tr.appendChild(td);
        }
        matrixElement.appendChild(tr);
      }  
  }

  function getWeights(table)
  {
    var n = table.rows.length
    var matrix = Array(n);

    for (var r = 0, n = table.rows.length; r < n; r++) {

        for (var c = 0, m = table.rows[r].cells.length; c < m; c++) {
            var cell = table.rows[r].cells[c];
            var value = Number(cell.children[0].value);
           
            if(r!= 0)
            {
                matrix[c] = value;
            }
        }
    }
    console.table(matrix);
    return matrix;
  }

  function getMatrix(table)
  {
    var n = table.rows.length - 1
    var matrix = Array(n);

    for (var r = 0; r <= n; r++) {

        if(r != 0)
        {
            matrix[r - 1] = Array(n);
        }

        for (var c = 0, m = table.rows[r].cells.length; c < m; c++) {
            var cell = table.rows[r].cells[c];
            var value = Number(cell.children[0].value);
           
            if(c != 0 && r!= 0)
            {
                matrix[r - 1 ][c - 1] = value;
            }
        }
    }
    console.table(matrix);
    return matrix;
  }

  function alloc()
  {
    var matrix = document.getElementById("nodeConnection");
   
    var nodeConnections = getMatrix(matrix);
    var processorConnections = getMatrix(document.getElementById("procConnections"));
    var weights = getWeights(document.getElementById("weights"));
    
    var task = {Weights : weights, JobRelations : nodeConnections, ProcessorRelations : processorConnections};

    var allocayionReques = new XMLHttpRequest();
    allocayionReques.open('POST', 'https://localhost:5001/api/allocations',true);
    
    allocayionReques.setRequestHeader("Content-Type", "application/json;charset=UTF-8");

    allocayionReques.onreadystatechange = function() {
      if (allocayionReques.readyState == XMLHttpRequest.DONE) 
      {
          alert(allocayionReques.responseText);
          var result =   allocayionReques.responseText;
          var allocation = JSON.parse(result);
          var n = allocation.jobSorting.length;
          var sortingMatrix = document.getElementById("jobSorting");
          createWeightsmatrix(n, sortingMatrix, allocation.jobSorting);
      }
        console.log("getted");
    };

    allocayionReques.onerror = function()
    {
        console.log("error");
    };
    
    //allocayionReques.
    allocayionReques.send(JSON.stringify(task));


    null;

  }