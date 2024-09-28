import { Carousel } from 'react-responsive-carousel';
import 'react-responsive-carousel/lib/styles/carousel.min.css';

const ImageCarousel = ({ photos }) => {
  return (
    <Carousel infiniteLoop>
      {photos.map((photo) => (
        <div key={photo.id}>
          <img src={photo.url} alt={photo.title} />
        </div>
      ))}
    </Carousel>
  );
};

export default ImageCarousel;