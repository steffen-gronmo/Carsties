type TProps = {
  center?: boolean;
  subtitle?: string;
  title: string;
};

const Heading = ({
  center,
  subtitle,
  title,
}: TProps) => {
  return (
    <div className={center ? 'text-center' : 'text-start'}>
      <h1 className="text-2xl font-bold">{title}</h1>
      {subtitle && <h2 className="font-light text-neutral-500">{subtitle}</h2>}
    </div>
  );
};

export default Heading;
