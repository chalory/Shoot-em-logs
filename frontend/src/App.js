import React from "react";
import { Route, Routes } from "react-router-dom";

import Landing from "./routes/Landing/Landing.route";
import Play from "./routes/Play/Play.route";

const App = () => {
    return (
        <Routes>
            <Route index element={<Landing />} />
            <Route path="/play" element={<Play />} />
        </Routes>
    );
};

export default App;
