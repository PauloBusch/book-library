function toQueryUrl(value) {
  if (!value) return '';

  const urlParams = Object.keys(value)
    .filter((k) => !['', null, undefined].includes(value[k]))
    .filter((k) => typeof k !== 'function')
    .map((k) => (Array.isArray(value[k])
      ? `${encodeQueryParam(k)}=${Array.from(value[k])
          .map(v => encodeQueryParam(v))
          .join(`&${encodeQueryParam(k)}=`)}`
      : `${encodeQueryParam(k)}=${encodeQueryParam(value[k])}`))
    .join('&');
  return urlParams ? `?${urlParams}` : '';
}

function encodeQueryParam(obj) {
  if (obj instanceof Date) {
    return obj.toISOString();
  }

  return encodeURIComponent(obj);
}

export default toQueryUrl;
