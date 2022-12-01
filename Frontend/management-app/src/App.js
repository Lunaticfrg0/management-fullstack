import { Routes, Route } from "react-router-dom" 
import Home from './routes/home/home.component';
import Client from './routes/client/client.component';
import NavigationBar from './routes/navigation-bar/navigation-bar.component';
import './App.css';
import ClientCreate from "./routes/client-create/client-create.component";
function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<NavigationBar/>}>
          <Route index element={<Home/>}/>        
          <Route path="client/:id" element={<Client/>}/>
          <Route path="create-client" element={<ClientCreate/>}/>
        </Route>
      </Routes>
    </div>
  );
}

export default App;
