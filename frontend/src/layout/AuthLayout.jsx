import { Outlet, useNavigate } from "react-router-dom";
import { useEffect } from "react";

export default function AuthLayout() {
  const navigate = useNavigate();

  useEffect(() => {
    const currentUser = localStorage.getItem("currentUser");
    if (currentUser) {
      navigate("/", { replace: true });
    }
  }, [navigate]);

  return (
    <div>
      <Outlet />
    </div>
  );
}
