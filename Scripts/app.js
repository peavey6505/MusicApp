function sequencer() {
    const kick = new Tone.Player("./drums/kick.wav").toMaster();
    const snare = new Tone.Player("./drums/snare.wav").toMaster();
    let index = 0;
  
    Tone.Transport.scheduleRepeat(repeat, "8n");
    Tone.Transport.start();
  
    function repeat() {
      let step = index % 8;
      let kickInputs = document.querySelector(
        `.kick input:nth-child(${step + 1})`
      );
      let snareInputs = document.querySelector(
        `.snare input:nth-child(${step + 1})`
      );
      if (kickInputs.checked) {
        kick.start();
        kickInputs.checked = false;
      }
      if (snareInputs.checked) {
        snare.start();
      }
      index++;
    }
  }
  
 // sequencer();

function playMelody(){
    const C = new Tone.Player("./piano/c.wav").toMaster();
    const D = new Tone.Player("./piano/d.wav").toMaster();
    const E = new Tone.Player("./piano/e.wav").toMaster();
    const F = new Tone.Player("./piano/f.wav").toMaster(); 
    let index = 0;
    let notes = [
        C, E, D, F
    ]



    Tone.Transport.scheduleRepeat(test, "8n");
    Tone.Transport.start();
  
    function test() {
      
        let step = index % 4;
        notes[index].start();
      index++;
    }

}



function playMelody2(){
    let currentNote = null;
    let previousNote = null;
    console.log("no niby dziala1");
    const C = new Tone.Player("~/Resources/piano/c.wav").toMaster();
    const D = new Tone.Player("~/Resources/piano/d.wav").toMaster();
    const E = new Tone.Player("~/Resources/piano/e.wav").toMaster();
    const F = new Tone.Player("~/Resources/piano/f.wav").toMaster();
    index = 0;  
    let notes = [
        C, D, E, F
    ]



      Tone.Transport.scheduleRepeat(function(time){

        index++;
          Tone.Draw.schedule(function(){
            currentNote = document.querySelector(
                `.kick input:nth-child(${index + 1})`
              );
              if(previousNote){
                previousNote.checked = false;
              }
             
              index = index %4;
              console.log("no niby dziala");
            
    
              currentNote.checked = true;
              previousNote = currentNote;
          },time)
        
          notes[index].start();
         

          

      }, "2n");

      
      Tone.Transport.start();
    
      function test2() {
        currentNote = document.querySelector(
            `.kick input:nth-child(${index + 1})`
          );
          if(previousNote){
            previousNote.checked = false;
          }
         
          index = index %4;
          console.log("no niby dziala");
        

          currentNote.checked = true;
          notes[index].start();
          previousNote = currentNote;

          index++;
        }
        

    }

function playMelody4() {
        let currentIndex = 0;
        let nextIndex = 1;

        console.log("no niby dziala1");
        const C = new Tone.Player("../Resources/piano/c.wav").toMaster();
        const D = new Tone.Player("../Resources/piano/d.wav").toMaster();
        const E = new Tone.Player("../Resources/piano/e.wav").toMaster();
        const F = new Tone.Player("../Resources/piano/f.wav").toMaster();
        const G = new Tone.Player("../Resources/piano/g.wav").toMaster();
        const A = new Tone.Player("../Resources/piano/a.wav").toMaster();
        const H = new Tone.Player("../Resources/piano/h.wav").toMaster();
        const C2 = new Tone.Player("../Resources/piano/c2.wav").toMaster();
        const D2 = new Tone.Player("../Resources/piano/d2.wav").toMaster();
        const E2 = new Tone.Player("../Resources/piano/e2.wav").toMaster();
        const Cis = new Tone.Player("../Resources/piano/cis.wav").toMaster();
        const Dis = new Tone.Player("../Resources/piano/dis.wav").toMaster();
        const Fis = new Tone.Player("../Resources/piano/fis.wav").toMaster();
        const Gis = new Tone.Player("../Resources/piano/gis.wav").toMaster();
        const B = new Tone.Player("../Resources/piano/b.wav").toMaster();
        const Cis2 = new Tone.Player("../Resources/piano/cis2.wav").toMaster();
        const Dis2 = new Tone.Player("../Resources/piano/dis2.wav").toMaster();

        let notes = [
            C,Cis, D,Dis, E, F,Fis, G,Gis, A,B, H, C2,Cis2, D2,Dis2, E2
        ]

        const cKey = document.querySelector(`button:nth-child(${1})`);
        const dKey = document.querySelector(`button:nth-child(${2})`);
        const eKey = document.querySelector(`button:nth-child(${3})`);
        const fKey = document.querySelector(`button:nth-child(${4})`);
        const gKey = document.querySelector(`button:nth-child(${5})`);
        const aKey = document.querySelector(`button:nth-child(${6})`);
        const hKey = document.querySelector(`button:nth-child(${7})`);
        const c2Key = document.querySelector(`button:nth-child(${8})`);
        const d2Key = document.querySelector(`button:nth-child(${9})`);
        const e2Key = document.querySelector(`button:nth-child(${10})`);

        const cisKey = document.querySelector(".black");
        const disKey = document.querySelector(".black2");
        const fisKey = document.querySelector(".black3");
        const gisKey = document.querySelector(".black4");
        const bKey = document.querySelector(".black5");
        const cis2Key = document.querySelector(".black6");
        const dis2Key = document.querySelector(".black7");

        console.log(cisKey);
        
        var keysDict = {
            C: [cKey, "w", C],
            Cis: [cisKey, "b",Cis],
            D: [dKey, "w", D],
            Dis: [disKey, "b", Dis],
            E: [eKey, "w", E],
            F: [fKey, "w", F],
            Fis: [fisKey, "b", Fis],
            G: [gKey, "w", G],
            Gis: [gisKey, "b", Gis],
            A: [aKey, "w", A],
            B: [bKey, "b", B],
            H: [hKey, "w", H],
            C2: [c2Key, "w", C2],
            Cis2: [cis2Key, "b", Cis2],
            D2: [d2Key, "w", D2],
            Dis2: [dis2Key, "b", Dis2],
            E2: [e2Key, "w", E2]
        }
        
        var twinkleeMelody = [
            keysDict.C, keysDict.C, keysDict.G, keysDict.G, keysDict.A, keysDict.A, keysDict.G,keysDict.G
        ]

        var twinkleMelody = [
             keysDict.C, keysDict.C, keysDict.C, keysDict.G, keysDict.Gis, keysDict.G, keysDict.Gis, keysDict.G,
             keysDict.C, keysDict.C, keysDict.C, keysDict.G, keysDict.Gis, keysDict.G, keysDict.Gis, keysDict.G,
             keysDict.C, keysDict.C, keysDict.C, keysDict.G, keysDict.Gis, keysDict.G, keysDict.Gis, keysDict.G,
             keysDict.C, keysDict.C, keysDict.C, keysDict.G, keysDict.Gis, keysDict.G, keysDict.Gis, keysDict.G,
        ]
        
        let currentKey = null;
        let nextKey = null;
        let previousKey = null;
        let previousKeyColor = null;
        
          Tone.Transport.scheduleRepeat(test2, "4n");
          Tone.Transport.start();
        
          function test2() {
              if (previousKey) {
                  if(previousKeyColor=="w")
                      previousKey.style.backgroundColor = "white";
                  else
                      previousKey.style.backgroundColor = "black";
              }
              currentKey = twinkleMelody[currentIndex][0];
              nextKey = twinkleMelody[nextIndex][0];
              previousKeyColor = twinkleMelody[currentIndex][1];

              currentKey.style.backgroundColor = "blue";
              nextKey.style.backgroundColor = "red";
              
              previousKey = currentKey;
              

              twinkleMelody[currentIndex][2].start();
              currentIndex++;
              nextIndex++;
              currentIndex = currentIndex % 32;
              nextIndex = nextIndex % 32;
              
              
            }
            
    
        }






var song = @Html.Raw(Json.Encode(MusicApp.Models.SongModel))


function testSong(){
    document.write(song.title);
}



function test1() {
    var seq = null;


    const cKey = [document.querySelector(`button:nth-child(${1})`), "w"];
    const dKey = [document.querySelector(`button:nth-child(${2})`), "w"];
    const eKey = [document.querySelector(`button:nth-child(${3})`), "w"];
    const fKey = [document.querySelector(`button:nth-child(${4})`), "w"];
    const gKey = [document.querySelector(`button:nth-child(${5})`), "w"];
    const aKey = [document.querySelector(`button:nth-child(${6})`), "w"];
    const hKey = [document.querySelector(`button:nth-child(${7})`), "w"];
    const c2Key = [document.querySelector(`button:nth-child(${8})`), "w"];
    const d2Key = [document.querySelector(`button:nth-child(${9})`), "w"];
    const e2Key = [document.querySelector(`button:nth-child(${10})`), "w"];

    const cisKey = document.querySelector(".black", "b");
    const disKey = document.querySelector(".black2", "b");
    const fisKey = [document.querySelector(".black3"), "b"];
    const gisKey = [document.querySelector(".black4"), "b"];
    const bKey = document.querySelector(".black5", "b");
    const cis2Key = document.querySelector(".black6", "b");
    const dis2Key = document.querySelector(".black7", "b");


    var keys = {
        C4: cKey,
        D4: dKey,
        E4: eKey,
        F4: fKey,
        G4: gKey,
        A4: aKey,
        "F#4": fisKey,
        "G#4": gisKey
    }

    var usedKeys = [cKey, gKey, aKey, fKey, eKey, dKey]
    
    var bars = [
         [["C4", "C4"], ["G4", "G4"], ["A4", "A4"], ["G4"]],
         [["F4", "F4"], ["E4", "E4"], ["D4", "D4"], ["C4"]],
         [["G4", "G4"], ["F4", "F4"], ["E4", "E4"], ["D4","D4"]],
         [["G4", "G4"], ["F4", "F4"], ["E4", "E4"], ["D4","D4"]],
         [["C4", "C4"], ["G4", "G4"], ["A4", "A4"], ["G4"]],
         [["F4", "F4"], ["E4", "E4"], ["D4", "D4"], ["C4"]],
         [["F#4", "G#4"], ["F#4", "G#4"]]
    ]

    var barNotesCounters = [7,7,8,8,7,7,4]

    var bar1UsedKeys = [cKey, gKey, aKey];
    var bar2UsedKeys = [fKey, eKey, dKey, cKey];
    var bar3UsedKeys = [gKey, fKey, eKey, dKey];
    var bar4UsedKeys = [gisKey, fisKey];
        
    var barsUsedKeys = [
        bar1UsedKeys, bar2UsedKeys,
        bar3UsedKeys, bar3UsedKeys,
        bar1UsedKeys, bar2UsedKeys,
        bar4UsedKeys
    ]
    

    var synth = new Tone.Synth().toMaster()
    function resetKeys(key) {
        if(key[1]=="w")
            key[0].style.backgroundColor = "white";
        else
            key[0].style.backgroundColor = "black";
    }
    function showUsingKeys(key){
        key[0].style.backgroundColor = "green";
    }
    var index = 0;
    var barIndex = 0;

    //pass in an array of events
    seq = new Tone.Sequence(function (time, note) {


        if (index == barNotesCounters[barIndex] ) {
            barsUsedKeys[barIndex].forEach(resetKeys);
            barIndex++;
            index = 0;
        }
        barsUsedKeys[barIndex].forEach(showUsingKeys);
      

        Tone.Draw.schedule(function () {
            keys[note][0].style.backgroundColor = "red";
            index++;
        }, time) //use AudioContext time of the event
        //subdivisions are given as subarrays
        synth.triggerAttackRelease(note, time)
    }, bars,"1n");

    seq.start();
    seq.loop = 4;
    Tone.Transport.bpm.value = 120;
    Tone.Transport.start();
}
    function playMelody44() {
        let currentNote = null;
        let previousNote = null;
        console.log("no niby dziala1");
        const C = new Tone.Player("../Resources/piano/c.wav").toMaster();
        const D = new Tone.Player("../Resources/piano/d.wav").toMaster();
        const E = new Tone.Player("../Resources/piano/e.wav").toMaster();
        const F = new Tone.Player("../Resources/piano/f.wav").toMaster();
        index = 0;
        let notes = [
            C, D, E, F
        ]


        Tone.Transport.scheduleRepeat(test2, "2n");
        Tone.Transport.start();

        function test2() {




            currentNote = document.querySelector(
              `button:nth-child(${index + 1})`
            );
            if (previousNote) {
                previousNote.style.backgroundColor = "white";
            }

            if (nextNote)
                nextNote = document.querySelector(
                 `button:nth-child(${index + 2})`
               );
            nextNote.style.backgroundColor = "red";


            console.log("no niby dziala");


            // currentNote.style.color = "black";
            console.log(index);

            notes[index].start();
            currentNote.style.backgroundColor = "black";
            previousNote = currentNote;
            currentNote = nextNote;

            index++;
            index = index % 4;
        }


    }
    function playMelody3(){
        var note = new Tone.Event(function(time, pitch){
            synth.triggerAttackRelease(pitch, "16n", time);
        }, "C2");
        
        //set the note to loop every half measure
        note.set({
            "loop" : true,
            "loopEnd" : "2n"
        });
        
        //start the note at the beginning of the Transport timeline
        note.start(0);
        console.log("dziala chuju")
        //stop the note on the 4th measure
        
    }


  function stopPlaying(){
      Tone.Transport.stop();
      Tone.Transpor.Mute
      seq.stop();
  }



  function playMelody6(){
        var bass = new Tone.MonoSynth({
        "volume" : -10,
        "envelope" : {
            "attack" : 0.1,
            "decay" : 0.3,
            "release" : 2,
        },
        "filterEnvelope" : {
            "attack" : 0.001,
            "decay" : 0.01,
            "sustain" : 0.5,
            "baseFrequency" : 200,
            "octaves" : 2.6
        }
    }).toMaster();
    var bassPart = new Tone.Sequence(function(time, note){
        bass.triggerAttackRelease(note, "16n", time);
    }, ["C2", ["C3", ["C3", "D2"]], "E2", ["D2", "A1"]]).start(0);


}