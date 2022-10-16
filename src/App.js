import React, { useState } from "react";

import Header from "./routes/Header/Header.component";
import Landing from "./routes/Landing/Landing.route";

import audioBg from "./assets/slinger_swagger.mp3";

const App = () => {
    const [isPlaying, setIsPlaying] = useState(false);

    const playAudio = () => {
        if (!isPlaying) {
            let audio = new Audio(audioBg);
            audio.play();
            audio.volume = 0.15;
            setIsPlaying(true);
        }
    };

    return (
        <div onClick={playAudio}>
            <Header />
            <main>
                <Landing />
            </main>
        </div>
    );
};

export default App;
