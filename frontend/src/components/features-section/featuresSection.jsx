import "./featuresSection.css";
import img1 from "../../assets/images/feature1.jpg";
import img2 from "../../assets/images/feature2.jpg";
import img3 from "../../assets/images/feature3.jpg";

export default function FeaturesSection() {
  const features = [
    {
      id: 1,
      image: img1,
      title: "IN THE TERRITORY OF BORDEAUX",
      subtitle: "WINE BRANDING",
    },
    {
      id: 2,
      image: img2,
      title: "WHAT MAKES US SPECIAL?",
      subtitle: "CONVERSATION WITH A SOMMELIER",
    },
    {
      id: 3,
      image: img3,
      title: "WITH INTERESTING INGREDIENTS",
      subtitle: "SIGNATURE COCKTAILS",
    },
  ];

  return (
    <section className="features-section">
      <div className="features-container">
        {features.map((feature) => (
          <div key={feature.id} className="feature-item">
            <img src={feature.image} alt={feature.title} />

            <div className="overlay">
              <p className="feature-title">{feature.title}</p>
              <h3 className="feature-subtitle">{feature.subtitle}</h3>
            </div>
            
          </div>
        ))}
      </div>
    </section>
  );
}
