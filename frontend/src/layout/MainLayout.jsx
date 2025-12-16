import { Outlet } from "react-router-dom";
import { useState } from "react";
import Navbar from "../components/navbar/Navbar";
import Footer from "../components/footer/footer";

export default function MainLayout() {
    const [searchTerm, setSearchTerm] = useState("");
  return (
    <>
      <Navbar onSearch={setSearchTerm} />
      <Outlet context={{ searchTerm }} />
      <Footer />
    </>
  );
}
