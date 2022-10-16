import React from "react";
import { Unity, useUnityContext } from "react-unity-webgl";

import "./Play.style.scss";

const Play = () => {
    const { unityProvider } = useUnityContext({
        loaderUrl: "assets/game.loader.js",
        dataUrl: "assets/game.data.unityweb",
        frameworkUrl: "assets/game.framework.js.unityweb",
        codeUrl: "assets/game.wasm.unityweb",
    });
    return (
        <section className="container">
            <Unity unityProvider={unityProvider} />
        </section>
    );
};

export default Play;
